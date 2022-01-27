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
        if (other.gameObject.tag == "Player")   //아이템이 플레이어와 충돌 시
        {
            
           

        }

        if (other.gameObject.tag == "Ground")       //아이템이 ground와 충돌 시
        {
            

            Destroy(this.gameObject);  //빗방울 제거

        }

    }
}
