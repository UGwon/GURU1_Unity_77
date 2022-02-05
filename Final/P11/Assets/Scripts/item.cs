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

        //sunItems[0].SetActive(false);   // ����
        //sunItems[0].SetActive(true);    // �ѱ�
    }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   //�� ������ �÷��̾�� �浹 ��
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

            if (CollisionPlayerSun.Instance.isFull)    //�� ������ 3�� ������
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


            ScoreManager.Instance.Score += 50;    //�� ������ ground�� �浹 �� �� ���� ���� ǥ��

            Destroy(this.gameObject);  //�� ������ ����

            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            BasicPlayer basicplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicPlayer>();

            if (player) player.Soundeffect();
            else if (basicplayer) basicplayer.Soundeffect();

        }

        if (other.gameObject.tag == "Ground")       //�� ������ ground�� �浹 ��
        {

            Destroy(this.gameObject);  //�� ������ ����

        }

    }

}