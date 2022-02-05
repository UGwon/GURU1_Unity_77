using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMgr
{
    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    //이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private으로.
    //private static GameMgr instance;
    
   
    public static int secondScore = ScoreManager.Instance.secondScore;
    public static int thirdScore = ScoreManager.Instance.thirdScore;
    public static int bestScore = ScoreManager.Instance.bestScore;
   

    


    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    /*public static GameMgr Instance
    {
        get
        {
            if (null == instance)
            {
                //게임 인스턴스가 없다면 하나 생성해서 넣어준다.
                instance = new GameMgr();
            }
            return instance;
        }
        set
        {
            secondScore = ScoreManager.Instance.secondScore;
            PlayerPrefs.SetInt("Second Score", secondScore);
            thirdScore = ScoreManager.Instance.thirdScore;
            PlayerPrefs.SetInt("Third Score", thirdScore);
        }
    }

    //생성자를 하나 만들어줘서 원하는 세팅을 해주면 좋다.
    public GameMgr()
    {
        


    }*/

}