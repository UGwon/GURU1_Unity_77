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

    public GameObject SendScoreObject;
    public GameObject Score;

    PlayerTemp playerTemp;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckingScore();    //���� ���� �� ��� ��ȯ ���� ���� üŷ��
    }

    public void GameStart()
    {
        stopTrigger = true;
        background3.SetActive(false);
        background1.SetActive(true);
        ScoreManager.Instance.currentScore = 0; //���� ���� �� ���� ���� 0���� �ʱ�ȭ
        StartCoroutine(CreateEenemyRoutine());
        Panel.SetActive(false);     //���� ���� �� �г� ��Ȱ��ȭ

        playerTemp = GameObject.Find("Player").GetComponent<PlayerTemp>();
        playerTemp.OnEnable();
    }

    public bool stopTrigger = true;

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        stopTrigger = false;
        StopCoroutine(CreateEenemyRoutine());
       // StartCoroutine(GameOverPanelDisabled(2.0f));    //���ӿ��� �г� 3�� �� �����
        Score = GameObject.Find("ScoreManager");
        Score.GetComponent<ScoreManager>().setScore();
        //SceneManager.LoadScene("RankingScene");
        DontDestroyOnLoad(SendScoreObject);
        Panel.SetActive(true);

    }


    public void GameOverPanelDisabled()
    {
        
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


   
    public void CheckingScore()         //���� ���� ���� �� ��� ��ȯ
    {
        if (ScoreManager.Instance.currentScore == 10)
        {
            background1.SetActive(false);
            background2.SetActive(true);
        }
        if (ScoreManager.Instance.currentScore == 20)
        {
            background2.SetActive(false);
            background3.SetActive(true);
        }
    

    }

   
}
