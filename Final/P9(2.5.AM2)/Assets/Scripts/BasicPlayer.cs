using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����(Player) �ӷ� 6 , ����(Player (1)) �ӷ� 2 ���۵��ڸ��� Fevertime
public class BasicPlayer : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float horizontal;

    public bool isDie = false;   //�÷��̾� ���� ���� �Ǵ�

    public bool AvoidChange = false; // ��� ���� ����

    [SerializeField] [Range(1f, 10f)] float speed = 3f;

    public Animator animator;

    public AudioClip umbrellaClip; // ��� ȹ�� �Ҹ�

    public AudioClip sunClip; // �� ȹ�� �Ҹ�

    private AudioSource itemAudio; // ����� ����� �ҽ� ������Ʈ

    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

        itemAudio = GetComponent<AudioSource>();

        // AvoidChange = true; // ó���� ���
    }

    void Update()
    {

        if (GameManager.Instance.stopTrigger)
        {
            Vector3 flipMove = Vector3.zero;

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                flipMove = Vector3.left;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                flipMove = Vector3.right;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            transform.position += flipMove * speed * Time.deltaTime;
        }

        PlayerTemp playerTemp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTemp>();
        if (playerTemp.tempSlider.value <= 0)
        {
            playerTemp.Die();
            animator.SetTrigger("Die");
            animator.Play("Die", 0, 1);
        }

        InScreen();

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Umbrella")   // ��� �浹 ��
        {
            animator.SetBool("Rain", true); // ��� ON
            AvoidChange = true;
            print("AvoidChange: " + AvoidChange);

            itemAudio.PlayOneShot(umbrellaClip); // ȿ���� ���
        }
        else
        {
            animator.SetBool("Rain", false); // ��� OFF

            print("�� ����");
        }

    }

    public void Soundeffect()
    {
        itemAudio.PlayOneShot(sunClip); // ȿ���� ���
        Debug.Log("�� ȿ���� ���");
    }

    private void InScreen()     //�÷��̾� ������ ȭ�� �������� �����ϵ���
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}
