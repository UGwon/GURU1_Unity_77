using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float horizontal;

    public bool isDie=false;   //�÷��̾� ���� ���� �Ǵ�

    private float defaultSpeed; // �����ӵ�

    public bool AvoidChange = false; // ��� ���� ����

    public Animator animator;

    [SerializeField] [Range(1f, 10f)] float speed = 3f;


    void Start()
    {
        defaultSpeed = speed; // �⺻�ӵ�

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.stopTrigger)
        {
            Vector3 flipMove = Vector3.zero;

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                flipMove = Vector3.left;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                flipMove = Vector3.right;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            transform.position += flipMove * speed * Time.deltaTime;
        }

        PlayerTemp playerTemp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTemp>();
        if (playerTemp.tempSlider.value <= 0)
        {
            playerTemp.Die();
            animator.SetTrigger("Die");
            animator.Play("Die", 0, 1);
        }

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

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Umbrella")   // ��� �浹 ��
        {
            animator.SetBool("Rain", true); // ��� ON
            AvoidChange = true;
            print("AvoidChange: " + AvoidChange);
        }
        else 
        {
            animator.SetBool("Rain", false); // ��� OFF

            print("�� ����");
        }
    }

        /*
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
        */


        private void InScreen()     //�÷��̾� ������ ȭ�� �������� �����ϵ���
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }

    
}