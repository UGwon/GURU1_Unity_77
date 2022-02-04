using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject background4;


    public GameObject SendScoreObject;
    public GameObject Score;

    public GameObject Cocoa;

    public GameObject enemyclone;

    public List<Enemy> EnemyList;

    public GameObject Rainbow;

    public GameObject ClearPanel;
    public GameObject player;

    public GameObject goalSlider;
    public GameObject endingPanel;

    public GameObject feverPanel;



   PlayerTemp playerTemp;

    void Start()
    {
        playerTemp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTemp>(); // PlayerTemp 가져옴
        playerTemp.tempSlider.gameObject.SetActive(false);  // 처음에 온도 이미지 비활성화
    }


    // Update is called once per frame
    void Update()
    {
        CheckingScore();    //점수 도달 시 배경 전환 위해 점수 체킹중
        currentTime += Time.deltaTime;
    }
    public bool stopTrigger = false;
    public GameObject[] sunOff;
    public void GameStart()
    {
        stopTrigger = true;
        sunOff[0].SetActive(true);
        sunOff[1].SetActive(true);
        sunOff[2].SetActive(true);
        background4.SetActive(false);
        background1.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(0, 0, 0);
        
        
        goalSlider.SetActive(true);
        
        ScoreManager.Instance.currentScore = 0; //게임 시작 시 현재 점수 0으로 초기화
        StartCoroutine(CreateEenemyRoutine());
        StartCoroutine(CreateCocoaRoutine());
        
        Panel.SetActive(false);     //게임 시작 시 패널 비활성화

        playerTemp.OnEnable(); // 게임 시작 시 온도계 리셋
    }

    

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        goalSlider.SetActive(false);

        stopTrigger = false;
        StopCoroutine(CreateEenemyRoutine());
        StopCoroutine(CreateCocoaRoutine());
        ClearManager.Instance.ClearItems();
        Score = GameObject.Find("ScoreManager");
        Score.GetComponent<ScoreManager>().setScore();
        //Panel.SetActive(true);

    }


    public void GameOverPanelDisabled()
    {
        
        GameOverPanel.SetActive(false);
    }


    IEnumerator CreateEenemyRoutine()   //눈송이 생성 루틴
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

        
           
            //EnemyList.Add(enemy);
        
        
    }
    public bool once=true;
    public void CheckingScore()         //일정 점수 도달 시 배경 전환
    {
        if (ScoreManager.Instance.currentScore > 200 && ScoreManager.Instance.currentScore < 499)
        {
            background1.SetActive(false);
            background2.SetActive(true);
        }
        if (ScoreManager.Instance.currentScore > 500 && ScoreManager.Instance.currentScore < 999 )
        {
            background2.SetActive(false);
            background3.SetActive(true);
        }
        if (ScoreManager.Instance.currentScore > 1000)
        {
            background3.SetActive(false);
            background4.SetActive(true);
        }

       if (ScoreManager.Instance.currentScore > 10000)
       {
            if (once)
            {
                endingMsg();
                once = false;
            }
            
       }
        
        

    }

    public void endingMsg()
    {
        endingPanel.SetActive(true);
        StopAllCoroutines();    //모든 코루틴 일시정지
        ClearManager.Instance.ClearItems(); //기존에 내리던 것들 청소

       
    }

    public void returnGame()
    {
       StartCoroutine(CreateEenemyRoutine());
       StartCoroutine(CreateCocoaRoutine());
        endingPanel.SetActive(false);
    }

    public void endGame()
    {
        
        endingPanel.SetActive(false);
        GameOver();
    }


    IEnumerator CreateCocoaRoutine()    //코코아 생성 루틴
    {
        while (stopTrigger)
        {
            yield return new WaitForSeconds(3);
            CreateCocoa();
            yield return new WaitForSeconds(10);
        }
    }

    private void CreateCocoa()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        Instantiate(Cocoa, pos, Quaternion.identity);
    }

    public bool FeverOn = false;
    public float currentTime=0;


    public void FeverTime()     //피버타임 진입 함수
    {
        print("call FeverTime");
        StopAllCoroutines();    //모든 코루틴 중단
        ClearManager.Instance.ClearItems(); //기존에 내리던 것들 청소
        
        StartCoroutine(CreateRainbowRoutine());
        ClearManager.Instance.ClearItems();
        
        StartCoroutine(CreateEenemyRoutine());
        StartCoroutine(CreateCocoaRoutine());
    }

    IEnumerator CreateRainbowRoutine()    //무지개 생성 루틴
    {
        FeverOn = true;
        feverPanel.SetActive(true);
        
        currentTime = 0;
        
        while (currentTime<5)
        {
            if (currentTime > 1.1f)
            {
                feverPanel.SetActive(false);
            }
            CreateRainbow();
            yield return new WaitForSeconds(0.05f);

            print("currentTime :" + currentTime);
            
        }

        FeverOn = false;
    }

    private void CreateRainbow()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        Instantiate(Rainbow, pos, Quaternion.identity);
    }

    //private void 

    
}

    


