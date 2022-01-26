using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    float currentTime; // ����ð�
    public float createTime = 1;
    public GameObject itemFactory;


    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(15, 30); // �����ð�
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // �ð� �帧

        if (currentTime > createTime) // ���� �ð��� �Ǹ�
        {
            GameObject item = Instantiate(itemFactory);
            item.transform.position = transform.position;
            currentTime = 0; // ����ð� �ʱ�ȭ

            createTime = UnityEngine.Random.Range(15, 20); // �����ð� �ٽ� ����
        }
    }
}
