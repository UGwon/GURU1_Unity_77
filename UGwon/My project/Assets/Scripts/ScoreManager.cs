using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    public int currentScore;
    public Text bestScoreUI;
    private int bestScore;
    public static ScoreManager Instance = null; //�̱��� ��ü

    void Awake()    //�̱��� ��ü�� ���� ������ ������ �ڱ��ڽ��� �Ҵ�
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public int Score    //get/set������Ƽ ����
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;   //�� �Ҵ�

            currentScoreUI.text = "�������� : " + currentScore;   //ȭ�鿡 ���� ���� ǥ��

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "�ְ����� : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);     //�ְ����� ����
            }
        }
    }




    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);    //�ְ����� �ҷ��� best score�� �ֱ�
        bestScoreUI.text = "�ְ����� : " + bestScore;   //ȭ�鿡 �ְ����� ǥ��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
