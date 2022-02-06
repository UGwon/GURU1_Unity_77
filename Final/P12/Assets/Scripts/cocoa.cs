using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocoa : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rigidbody;

    public float newTemp = 12f; // ���ھ� ���Ƕ� ü�� ȸ����

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
        if (other.gameObject.tag == "Player")   //���ھ� �÷��̾�� �浹 ��
        {
            ScoreManager.Instance.Score += 80;
            Destroy(this.gameObject);  //���ھ� ����

            playerTemp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTemp>();
            playerTemp.RestoreTemp(newTemp); // ü�� ȸ�� �µ��� ����
        }

        if (other.gameObject.tag == "Ground")       //���ھ� ground�� �浹 ��
        {
            
            Destroy(this.gameObject);  //���ھ� ����

        }

    }
}