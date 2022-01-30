using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public string type;
    Rigidbody2D rigid;
    public GameObject slotItem;

    // Update is called once per frame

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 2;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //아이템 플레이어와 충돌 시
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


            ScoreManager.Instance.Score += 100;    //아이템 ground와 충돌 할 때 마다 점수 표시

            Destroy(this.gameObject);  //아이템 제거

        }

        if (other.gameObject.tag == "Ground")       //아이템 ground와 충돌 시
        {

            Destroy(this.gameObject);  //아이템 제거

        }

    }

}