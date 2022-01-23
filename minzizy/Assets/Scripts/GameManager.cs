using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject Enemy;

    private int score;

    [SerializeField]
    private Text scoreTxt;

    private Text askStart;
    
    [SerializeField]
    private GameObject Panel;
    
    [SerializeField]
    private GameObject GameOverPanel;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        stopTrigger = true;
        ScoreManager.Instance.currentScore = 0; //게임 시작 시 현재 점수 0으로 초기화
        StartCoroutine(CreateEenemyRoutine());
        Panel.SetActive(false);     //게임 시작 시 패널 비활성화
    }

    public bool stopTrigger = true;

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        stopTrigger = false;
        StopCoroutine(CreateEenemyRoutine());
        StartCoroutine(GameOverPanelDisabled(3.0f));    //게임오버 패널 3초 후 사라짐
        Panel.SetActive(true);

    }


    IEnumerator GameOverPanelDisabled(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameOverPanel.SetActive(false);
    }


    IEnumerator CreateEenemyRoutine()
    {
        while (stopTrigger)
        {
            CreateEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void CreateEnemy()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = 0.0f;
        Instantiate(Enemy, pos, Quaternion.identity);
    }
}
