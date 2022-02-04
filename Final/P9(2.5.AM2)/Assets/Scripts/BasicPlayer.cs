using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슈리(Player) 속력 6 , 유시(Player (1)) 속력 2 시작되자마자 Fevertime
public class BasicPlayer : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float horizontal;

    public bool isDie = false;   //플레이어 생존 여부 판단

    public bool AvoidChange = false; // 우산 적용 변수

    [SerializeField] [Range(1f, 10f)] float speed = 3f;

    public Animator animator;

    public AudioClip umbrellaClip; // 우산 획득 소리

    public AudioClip sunClip; // 해 획득 소리

    private AudioSource itemAudio; // 사용할 오디오 소스 컴포넌트

    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

        itemAudio = GetComponent<AudioSource>();

        // AvoidChange = true; // 처음에 우비
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
        if (other.gameObject.tag == "Umbrella")   // 우산 충돌 시
        {
            animator.SetBool("Rain", true); // 우비 ON
            AvoidChange = true;
            print("AvoidChange: " + AvoidChange);

            itemAudio.PlayOneShot(umbrellaClip); // 효과음 재생
        }
        else
        {
            animator.SetBool("Rain", false); // 우비 OFF

            print("눈 맞음");
        }

    }

    public void Soundeffect()
    {
        itemAudio.PlayOneShot(sunClip); // 효과음 재생
        Debug.Log("해 효과음 재생");
    }

    private void InScreen()     //플레이어 움직임 화면 내에서만 가능하도록
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}
