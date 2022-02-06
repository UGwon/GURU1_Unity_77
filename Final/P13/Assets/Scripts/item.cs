using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject slotItem;
    public GameObject clearSlot;

    
    //public GameObject[] sunItems;
    public GameObject sunItems;
    // Update is called once per frame

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 2;

        //sunItems[0].SetActive(false);   // 끄기
        //sunItems[0].SetActive(true);    // 켜기
    }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //해 아이템 플레이어와 충돌 시
        {
            CollisionPlayerSun.Instance.TurnOnSun();
            /*
            for (int i = 0; i < 3; i++)
            {

                CollisionPlayerSun.Instance.isCollide = true;
                if (inven.slots[i].isEmpty)
                {
                    GameObject obj = Instantiate(
                        slotItem, inven.slots[i].slotObj.transform, false);

                    inven.slots[i].isEmpty = false;
                    break;

                }
            }*/

            if (CollisionPlayerSun.Instance.isFull)    //해 아이템 3개 모으면
            {
                print("full slot");
                GameManager.Instance.FeverTime();
                CollisionPlayerSun.Instance.clearSlot();

                /*for(int i=0; i < inven.slots.Count; i++)
                {

                    //Instantiate(clearSlot, inven.slots[i].slotObj.transform, false);
                    //Destroy(inven.slots[i]);
                }*/


            }


            ScoreManager.Instance.Score += 50;    //해 아이템 ground와 충돌 할 때 마다 점수 표시

            Destroy(this.gameObject);  //해 아이템 제거

            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            BasicPlayer basicplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicPlayer>();

            if (player) player.Soundeffect();
            else if (basicplayer) basicplayer.Soundeffect();

        }

        if (other.gameObject.tag == "Ground")       //해 아이템 ground와 충돌 시
        {

            Destroy(this.gameObject);  //해 아이템 제거

        }

    }

}