using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float speed=3;

    private float horizontal;

    public bool isDie=false;   //플레이어 생존 여부 판단

    private float defaultSpeed; // 높은속도

    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speed; // 기본속도

        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(GameManager.Instance.stopTrigger)
        Move();
        InScreen();

        if (Input.GetKey(KeyCode.Space)) // 스페이스바 눌렀을때 가속
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
    
    private void InScreen()     //플레이어 움직임 화면 내에서만 가능하도록
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}