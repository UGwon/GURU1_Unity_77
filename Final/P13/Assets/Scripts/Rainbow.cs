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
        if (other.gameObject.tag == "Player")   //레인보우 플레이어와 충돌 시
        {
            ScoreManager.Instance.Score += 100;
            Destroy(gameObject);  //레인보우 제거

            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            BasicPlayer basicplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicPlayer>();

            if (player) player.RainbowSound();
            else if (basicplayer) basicplayer.RainbowSound();
        }

        if (other.gameObject.tag == "Ground")       //레인보우 ground와 충돌 시
        {


            Destroy(gameObject);  //레인보우 제거

        }

    }
}
