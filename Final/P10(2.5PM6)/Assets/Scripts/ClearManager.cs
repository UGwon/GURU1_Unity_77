using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    //�̱���
    private static ClearManager _instance;

    public static ClearManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ClearManager>();
            }
            return _instance;
        }
    }

    float currentTime=0;
    
    public GameObject cleanerFactory;

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "obj")   //cleaner obj(������, ���ھ�, �� ������)�� �浹 ��
        {
            Destroy(other.gameObject);  //cleaner ����
        }

        if (other.gameObject.tag == "Enemy")   //cleaner obj(������, ���ھ�, �� ������)�� �浹 ��
        {
            Destroy(other.gameObject);  //cleaner ����
        }

        if (other.gameObject.tag == "Ground")       //������ ground�� �浹 ��
        {
            Destroy(this.gameObject);  //cleaner ����
        }
    }
    

    public void ClearItems()
    {
        print("ClearItems()");
        GameObject cleaner = Instantiate(cleanerFactory);
        cleaner.transform.position = transform.position;


    }
    
}
