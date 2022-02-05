using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    
    public Text currentScoreUI;
    public int currentScore;
    public Text bestScoreUI;
    public int bestScore;
    public int secondScore=1;
    public int thirdScore=-1;

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

            currentScoreUI.text = "" + currentScore;   //ȭ�鿡 ���� ���� ǥ��

           ////
            
        }
    }




    void Start()
    {
        /*PlayerPrefs.SetInt("Third Score", 0);
        PlayerPrefs.SetInt("Second Score", 10);
        PlayerPrefs.SetInt("Best Score", 20);*/

        bestScore = PlayerPrefs.GetInt("Best Score", 0);    //�ְ����� �ҷ��� best score�� �ֱ�
        bestScoreUI.text = "" + bestScore;   //ȭ�鿡 �ְ����� ǥ��
        secondScore = PlayerPrefs.GetInt("Second Score", 0);
        thirdScore= PlayerPrefs.GetInt("Third Score", 0);

    }

    // Update is called once per frame
    void Update()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        secondScore = PlayerPrefs.GetInt("Second Score", 0);
        thirdScore = PlayerPrefs.GetInt("Third Score", 0);
        
        if (currentScore >= thirdScore && currentScore < secondScore)
        {
            thirdScore = currentScore;
            PlayerPrefs.SetInt("Third Score", thirdScore);
        }
        else if (currentScore >= secondScore && currentScore < bestScore && currentScore > thirdScore)
        {
            secondScore = currentScore;
            PlayerPrefs.SetInt("Second Score", secondScore);
        }
        else if (currentScore >= bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "BEST : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);     //�ְ����� ����
        }
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        secondScore = PlayerPrefs.GetInt("Second Score", 0);
        thirdScore = PlayerPrefs.GetInt("Third Score", 0);
    }

    public void setScore()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        secondScore = PlayerPrefs.GetInt("Second Score", 0);
        thirdScore = PlayerPrefs.GetInt("Third Score", 0);
    }


}
