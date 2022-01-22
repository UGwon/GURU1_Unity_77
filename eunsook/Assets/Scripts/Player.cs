using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float speed=3;

    private float horizontal;

    public bool isDie=false;   //�÷��̾� ���� ���� �Ǵ�

    private float defaultSpeed; // �����ӵ�

    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speed; // �⺻�ӵ�

        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(GameManager.Instance.stopTrigger)
        Move();
        InScreen();

        if (Input.GetKey(KeyCode.Space)) // �����̽��� �������� ����
        {
            defaultSpeed = 6;
        }
        else
        {
            defaultSpeed = speed;
        }

    }

    private void Move()
    {
        rigidbody.velocity = new Vector2(horizontal * defaultSpeed, rigidbody.velocity.y);
    }
    
    private void InScreen()     //�÷��̾� ������ ȭ�� �������� �����ϵ���
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}