using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMgr
{
    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    //private static GameMgr instance;
    
   
    public static int secondScore = ScoreManager.Instance.secondScore;
    public static int thirdScore = ScoreManager.Instance.thirdScore;
    public static int bestScore = ScoreManager.Instance.bestScore;
   

    


    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    /*public static GameMgr Instance
    {
        get
        {
            if (null == instance)
            {
                //���� �ν��Ͻ��� ���ٸ� �ϳ� �����ؼ� �־��ش�.
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

    //�����ڸ� �ϳ� ������༭ ���ϴ� ������ ���ָ� ����.
    public GameMgr()
    {
        


    }*/

}