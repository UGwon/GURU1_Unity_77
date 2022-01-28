using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float horizontal;

    public bool isDie=false;   //�÷��̾� ���� ���� �Ǵ�

    private float defaultSpeed; // �����ӵ�

    [SerializeField] [Range(1f, 10f)] float speed = 3f;


    void Start()
    {
        defaultSpeed = speed; // �⺻�ӵ�

        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 flipMove = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") <0)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        else if(Input.GetAxisRaw("Horizontal")>0)
        {
            flipMove = Vector3.right;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        transform.position += flipMove * speed* Time.deltaTime;
    }
  
    void FixedUpdate()
    {
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

    private void InScreen()     //�÷��̾� ������ ȭ�� �������� �����ϵ���
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}