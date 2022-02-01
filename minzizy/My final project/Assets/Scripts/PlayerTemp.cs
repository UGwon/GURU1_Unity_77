using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTemp : MonoBehaviour
{

    public Slider tempSlider; // �µ��� ǥ���� UI �����̴�

    public float startingTemp = 36f; // ���� �µ�

    public float temp { get; protected set; } //���� �µ�

    public bool dead { get; protected set; } // ��� ����

    public AudioClip hitClip; // �� ���� �� ���� �Ҹ�

    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // ������ ����ż� �ð��� �������� �µ� ������
        temp -= Time.deltaTime;

        // ���ŵ� �µ��� �µ� �̹����� �ݿ�
        tempSlider.value = temp;

        // �µ��� 0 ���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if (temp <= 0 && !dead)
        {
            Die();
        }

    }

    // ����ü�� Ȱ��ȭ�� �� ���¸� ����
    public void OnEnable()
    {

        // �µ� �̹��� Ȱ��ȭ
        tempSlider.gameObject.SetActive(true);

        // ������� ���� ���·� ����
        dead = false;

        // �µ��� ���� �µ��� �ʱ�ȭ
        temp = startingTemp;

        // �µ� �̹��� �ִ��� �⺻ �µ������� ����
        tempSlider.maxValue = startingTemp;

        // �µ� �̹����� ���� ���� �µ������� ����
        tempSlider.value = temp;

    }

    // ������� �Դ� ���
    public void OnDamage(float damage)
    {

        if (!dead)
        {
            // ������� ���� ��쿡�� ȿ���� ���
            playerAudio.PlayOneShot(hitClip);
        }

        // �������ŭ �µ� ����
        temp -= damage;

        // ���ŵ� �µ��� �µ� �̹����� �ݿ�
        tempSlider.value = temp;

    }

    // �µ� ȸ��
    public void RestoreTemp(float newTemp)
    {
        if (dead)
        {
            // �̹� ����� ��� �µ��� ȸ���� �� ����
            return;
        }
        // �µ� �߰�
        temp += newTemp;

        // ���ŵ� �µ��� �µ� �̹����� �ݿ�
        tempSlider.value = temp;
    }

    // ��� ó��
    public void Die()
    {
        // ��� ���¸� ������ ����
        dead = true;

        // �µ� �̹��� ��Ȱ��ȭ
        tempSlider.gameObject.SetActive(false);

        //���ӿ���
        GameManager.Instance.GameOver();
    }

}
