using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocoa : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //빗방울 플레이어와 충돌 시
        {
            ScoreManager.Instance.Score += 80;
            Destroy(this.gameObject);  //빗방울 제거


        }

        if (other.gameObject.tag == "Ground")       //빗방울 ground와 충돌 시
        {
            ScoreManager.Instance.Score++;    //빗방울 ground와 충돌 할 때 마다 점수 표시

            Destroy(this.gameObject);  //빗방울 제거

        }

    }
}