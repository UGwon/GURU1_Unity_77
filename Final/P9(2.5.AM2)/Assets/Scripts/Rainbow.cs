using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector2.down;
        transform.position += dir * Time.deltaTime*10;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //���κ��� �÷��̾�� �浹 ��
        {
            ScoreManager.Instance.Score += 100;
            Destroy(gameObject);  //���κ��� ����
        }

        if (other.gameObject.tag == "Ground")       //���κ��� ground�� �浹 ��
        {


            Destroy(gameObject);  //���κ��� ����

        }

    }
}
