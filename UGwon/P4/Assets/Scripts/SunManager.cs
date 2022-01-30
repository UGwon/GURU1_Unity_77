using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    float currentTime; // 현재시간
    public float createTime = 1;
    public GameObject itemFactory;


    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(20, 60); // 생성시간
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.stopTrigger == true)
        {
            currentTime += Time.deltaTime; // 시간 흐름

            if (currentTime > createTime) // 일정 시간이 되면
            {
                GameObject item = Instantiate(itemFactory);
                item.transform.position = transform.position;
                currentTime = 0; // 현재시간 초기화

                createTime = UnityEngine.Random.Range(20, 60); // 생성시간 다시 설정
            }
        }

    }
}
