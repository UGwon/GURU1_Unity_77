using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rigidbody;

    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.down;
        // transform.position += dir * speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //�������� �÷��̾�� �浹 ��
        {
            
           

        }

        if (other.gameObject.tag == "Ground")       //�������� ground�� �浹 ��
        {
            

            Destroy(this.gameObject);  //����� ����

        }

    }
}
