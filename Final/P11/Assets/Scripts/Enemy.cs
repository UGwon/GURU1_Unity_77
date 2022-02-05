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

    public float damage = 12f; // ������ �����

    PlayerTemp playerTemp;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector2.Distance(player.transform.position, transform.position);

        rigidbody.gravityScale += Time.deltaTime*0.1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")   // ������ �÷��̾�� �浹 ��
        {

            Player player = other.gameObject.GetComponent<Player>();

            BasicPlayer basicplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicPlayer>();

            playerTemp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTemp>();

            if (player)
            {
                if (player.AvoidChange == true) //  ��������
                {
                    Destroy(this.gameObject);  // ������ ����
                    player.AvoidChange = false; // ��� ���� ����

                    print("AvoidChange: " + player.AvoidChange);
                }
                else
                {
                    playerTemp.OnDamage(damage); // ������ ����� �µ��� ����

                    Destroy(this.gameObject);  //������ ����
                }
            }
            else if (basicplayer)
            {
                if (basicplayer.AvoidChange == true) //  ��������
                {
                    Destroy(this.gameObject);  // ������ ����
                    basicplayer.AvoidChange = false; // ��� ���� ����

                    print("AvoidChange: " + basicplayer.AvoidChange);
                }
                else
                {
                    playerTemp.OnDamage(damage); // ������ ����� �µ��� ����

                    Destroy(this.gameObject);  //������ ����
                }
            }

        }


        if (other.gameObject.tag == "Ground")       //������ ground�� �浹 ��
        {
            //ScoreManager.Instance.Score++;    //������ ground�� �浹 �� �� ���� ���� ǥ��
            DistanceEnemyPlayer();
            Destroy(this.gameObject);  //������ ����

        }



    }

    public void DistanceEnemyPlayer()   //�����̿� �÷��̾� ���� �Ÿ� ������ ���� ������ ���� �߻�
    {

        print("dis : " + dis);
        if (dis <= 1)
        {
            ScoreManager.Instance.Score += 10;
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
