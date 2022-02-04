using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //�̱���
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
        playerTemp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTemp>(); // PlayerTemp ������
        playerTemp.tempSlider.gameObject.SetActive(false);  // ó���� �µ� �̹��� ��Ȱ��ȭ
    }


    // Update is called once per frame
    void Update()
    {
        CheckingScore();    //���� ���� �� ��� ��ȯ ���� ���� üŷ��
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
        
        ScoreManager.Instance.currentScore = 0; //���� ���� �� ���� ���� 0���� �ʱ�ȭ
        StartCoroutine(CreateEenemyRoutine());
        StartCoroutine(CreateCocoaRoutine());
        
        Panel.SetActive(false);     //���� ���� �� �г� ��Ȱ��ȭ

        playerTemp.OnEnable(); // ���� ���� �� �µ��� ����
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


    IEnumerator CreateEenemyRoutine()   //������ ���� ��ƾ
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
    public void CheckingScore()         //���� ���� ���� �� ��� ��ȯ
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
        StopAllCoroutines();    //��� �ڷ�ƾ �Ͻ�����
        ClearManager.Instance.ClearItems(); //������ ������ �͵� û��

       
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


    IEnumerator CreateCocoaRoutine()    //���ھ� ���� ��ƾ
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


    public void FeverTime()     //�ǹ�Ÿ�� ���� �Լ�
    {
        print("call FeverTime");
        StopAllCoroutines();    //��� �ڷ�ƾ �ߴ�
        ClearManager.Instance.ClearItems(); //������ ������ �͵� û��
        
        StartCoroutine(CreateRainbowRoutine());
        ClearManager.Instance.ClearItems();
        
        StartCoroutine(CreateEenemyRoutine());
        StartCoroutine(CreateCocoaRoutine());
    }

    IEnumerator CreateRainbowRoutine()    //������ ���� ��ƾ
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

    


