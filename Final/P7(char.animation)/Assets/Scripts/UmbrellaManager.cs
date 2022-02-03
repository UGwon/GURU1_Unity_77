using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaManager : MonoBehaviour
{
    float currentTime; // 현재시간
    public float createTime = 1;
    public GameObject umbFactory;


    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(10, 15); // 생성시간
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // 시간 흐름

        if (currentTime > createTime) // 일정 시간이 되면
        {
            GameObject item = Instantiate(umbFactory);
            item.transform.position = transform.position;
            currentTime = 0; // 현재시간 초기화

            createTime = UnityEngine.Random.Range(10, 15); // 생성시간 다시 설정
        }
    }
}
