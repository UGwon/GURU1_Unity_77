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

            currentScoreUI.text = "" + currentScore;   //화면에 현재 점수 표시

           ////
            
        }
    }




    void Start()
    {
        /*PlayerPrefs.SetInt("Third Score", 0);
        PlayerPrefs.SetInt("Second Score", 10);
        PlayerPrefs.SetInt("Best Score", 20);*/

        bestScore = PlayerPrefs.GetInt("Best Score", 0);    //최고점수 불러와 best score에 넣기
        bestScoreUI.text = "" + bestScore;   //화면에 최고점수 표시
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
            PlayerPrefs.SetInt("Best Score", bestScore);     //최고점수 저장
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
