using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTemp : MonoBehaviour
{

    public Slider tempSlider; // 온도를 표시할 UI 슬라이더

    public float startingTemp = 36f; // 시작 온도

    public float temp { get; protected set; } //현재 온도

    public bool dead { get; protected set; } // 사망 상태

    public AudioClip hitClip; // 눈 맞을 때 나는 소리

    private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // 추위에 노출돼서 시간이 지날수록 온도 떨어짐
        temp -= Time.deltaTime;

        // 갱신된 온도를 온도 이미지에 반영
        tempSlider.value = temp;

        // 온도가 0 이하 && 아직 죽지 않았다면 사망 처리 실행
        if (temp <= 0 && !dead)
        {
            Die();
        }

    }

    // 생명체가 활성화될 때 상태를 리셋
    public void OnEnable()
    {

        // 온도 이미지 활성화
        tempSlider.gameObject.SetActive(true);

        // 사망하지 않은 상태로 시작
        dead = false;

        // 온도를 시작 온도로 초기화
        temp = startingTemp;

        // 온도 이미지 최댓값을 기본 온도값으로 변경
        tempSlider.maxValue = startingTemp;

        // 온도 이미지의 값을 현재 온도값으로 변경
        tempSlider.value = temp;

    }

    // 대미지를 입는 기능
    public void OnDamage(float damage)
    {

        if (!dead)
        {
            // 사망하지 않은 경우에만 효과음 재생
            playerAudio.PlayOneShot(hitClip);
        }

        // 대미지만큼 온도 감소
        temp -= damage;

        // 갱신된 온도를 온도 이미지에 반영
        tempSlider.value = temp;

    }

    // 온도 회복
    public void RestoreTemp(float newTemp)
    {
        if (dead)
        {
            // 이미 사망한 경우 온도를 회복할 수 없음
            return;
        }
        // 온도 추가
        temp += newTemp;

        // 갱신된 온도를 온도 이미지에 반영
        tempSlider.value = temp;
    }

    // 사망 처리
    public void Die()
    {
        // 사망 상태를 참으로 변경
        dead = true;

        // 온도 이미지 비활성화
        tempSlider.gameObject.SetActive(false);

        //게임오버
        GameManager.Instance.GameOver();
    }

}
