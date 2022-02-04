using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocoa : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rigidbody;

    public float newTemp = 12f; // 코코아 마실때 체온 회복양

    PlayerTemp playerTemp;

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
        if (other.gameObject.tag == "Player")   //코코아 플레이어와 충돌 시
        {
            ScoreManager.Instance.Score += 80;
            Destroy(this.gameObject);  //코코아 제거

            playerTemp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTemp>();
            playerTemp.RestoreTemp(newTemp); // 체온 회복 온도계 적용
        }

        if (other.gameObject.tag == "Ground")       //코코아 ground와 충돌 시
        {
            
            Destroy(this.gameObject);  //코코아 제거

        }

    }
}