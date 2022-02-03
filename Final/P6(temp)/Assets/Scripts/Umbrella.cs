using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    private static Umbrella _instance;

    public static Umbrella Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Umbrella>();
            }
            return _instance;
        }
    }
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    //private void OnTriggerEnter2D(Collider2D other)
    {
        if (collision.gameObject.tag == "Player")   //플레이어와 충돌 시
        {

           // AvoidChange = true;
            Destroy(this.gameObject);  //제거

        }
    }
}
