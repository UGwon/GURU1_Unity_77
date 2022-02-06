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
        if (other.gameObject.tag == "Player")   //����� �÷��̾�� �浹 ��
        {
            ScoreManager.Instance.Score += 80;
            Destroy(this.gameObject);  //����� ����


        }

        if (other.gameObject.tag == "Ground")       //����� ground�� �浹 ��
        {
            ScoreManager.Instance.Score++;    //����� ground�� �浹 �� �� ���� ���� ǥ��

            Destroy(this.gameObject);  //����� ����

        }

    }
}