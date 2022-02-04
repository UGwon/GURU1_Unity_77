using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RankScore : MonoBehaviour
{
    public Text firstScoreUI;
    public int r1;
    public Text secondScoreUI;
    public int r2; 
    public Text thirdScoreUI;
    public int r3;
    GameObject RankingManager;
    // Start is called before the first frame update
    void Start()
    {
        /* RankingManager = GameObject.Find("SendScore");
         r1 = RankingManager.GetComponent<sendingScore>().bs;

         print("bestScore " + r1);

         bestScoreUI.text = "1등 : " + r1;*/

       


    }

    // Update is called once per frame
    void Update()
    {
        r1 = GameMgr.bestScore;


        firstScoreUI.text = "1등 : " + r1;

        r2 = GameMgr.secondScore;
        if (r2 < 1)
        {
            secondScoreUI.text = "2등 : 정보없음";
        }
        else
        {
            secondScoreUI.text = "2등 : " + r2;
        }


        r3 = GameMgr.thirdScore;
        if (r3 < 1)
        {
            thirdScoreUI.text = "3등 : 정보없음";
        }
        else
        {
            thirdScoreUI.text = "3등 : " + r3;
        }

    }


}
