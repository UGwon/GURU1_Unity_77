using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
    private GameObject panel;

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

        StartCoroutine(CreateEenemyRoutine());
        panel.SetActive(false);
    }

    private bool stopTrigger = true;

    public void GameOver()
    {
        stopTrigger = false;
        StopCoroutine(CreateEenemyRoutine());

    }

    public void Score()
    {
        score++;
        Debug.Log("score : " + score);
        scoreTxt.text = "현재 점수 : " + score;
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
