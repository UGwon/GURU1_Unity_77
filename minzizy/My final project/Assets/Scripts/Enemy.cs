using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rigidbody;

    public float dis;
     
    public GameObject player;

    public float damage = 12f; // 눈송이 대미지

    PlayerTemp playerTemp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector2.Distance(player.transform.position, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //빗방울 플레이어와 충돌 시
        {
            /*
             if(GameManager.Instance.stopTrigger == true)
             {
                 GameManager.Instance.GameOver();
             }
             */

            playerTemp = GameObject.Find("Player").GetComponent<PlayerTemp>();

            playerTemp.OnDamage(damage); // 눈송이 대미지 온도계 적용

            Destroy(this.gameObject);  //눈송이 제거

        }

        if (other.gameObject.tag == "Ground")       //눈송이 ground와 충돌 시
        {
            //ScoreManager.Instance.Score++;    //빗방울 ground와 충돌 할 때 마다 점수 표시
            DistanceEnemyPlayer();
            Destroy(this.gameObject);  //눈송이 제거

        }

        

    }

    public void DistanceEnemyPlayer()   //눈송이와 플레이어 사이 거리 측정해 점수 증가에 차이 발생
        {

            print("dis : " + dis);
            if (dis <= 1)   
            {
                ScoreManager.Instance.Score+=10;
            }
            else if (dis <= 3 && dis > 1)
            {
                ScoreManager.Instance.Score += 7;
            }
            else if (dis <= 5 && dis > 3)
            {
            ScoreManager.Instance.Score += 4;
            }
            else 
            {
               ScoreManager.Instance.Score++;
            }



        }
    
}
