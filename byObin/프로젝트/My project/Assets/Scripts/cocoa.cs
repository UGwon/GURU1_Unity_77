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
        if (other.gameObject.tag == "Player")   //内内酒 敲饭捞绢客 面倒 矫
        {
            ScoreManager.Instance.Score += 80;
            Destroy(this.gameObject);  //内内酒 力芭


        }

        if (other.gameObject.tag == "Ground")       //内内酒 ground客 面倒 矫
        {
            

            Destroy(this.gameObject);  //内内酒 力芭

        }

    }
}