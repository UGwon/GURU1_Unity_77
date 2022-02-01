using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public string type;
    Rigidbody2D rigid;
    public GameObject slotItem;
    public GameObject clearSlot;



    // Update is called once per frame

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 2;

    }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //해 아이템 플레이어와 충돌 시
        {

            Inventory inven = other.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {
                if (inven.slots[i].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;

                    break;
                }
            }
            if (inven.slots[2].isEmpty == false)    //해 아이템 3개 모으면
            {
                print("full slot");
                GameManager.Instance.FeverTime();
                
            }


            ScoreManager.Instance.Score += 100;    //해 아이템 ground와 충돌 할 때 마다 점수 표시

            Destroy(this.gameObject);  //해 아이템 제거

        }

        if (other.gameObject.tag == "Ground")       //해 아이템 ground와 충돌 시
        {

            Destroy(this.gameObject);  //해 아이템 제거

        }

    }

}