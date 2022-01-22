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
    public static ScoreManager Instance = null; //싱글톤 객체

    void Awake()    //싱글톤 객체에 값이 없으면 생성된 자기자신을 할당
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public int Score    //get/set프로퍼티 구현
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;   //값 할당

            currentScoreUI.text = "현재점수 : " + currentScore;   //화면에 현재 점수 표시

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고점수 : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);     //최고점수 저장
            }
        }
    }




    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);    //최고점수 불러와 best score에 넣기
        bestScoreUI.text = "최고점수 : " + bestScore;   //화면에 최고점수 표시
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
