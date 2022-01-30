using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaManager : MonoBehaviour
{
    float currentTime; // ����ð�
    public float createTime = 1;
    public GameObject umbFactory;


    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(10, 15); // �����ð�
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // �ð� �帧

        if (currentTime > createTime) // ���� �ð��� �Ǹ�
        {
            GameObject item = Instantiate(umbFactory);
            item.transform.position = transform.position;
            currentTime = 0; // ����ð� �ʱ�ȭ

            createTime = UnityEngine.Random.Range(10, 15); // �����ð� �ٽ� ����
        }
    }
}
