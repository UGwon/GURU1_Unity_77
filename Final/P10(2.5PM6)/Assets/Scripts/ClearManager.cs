using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    //싱글톤
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
        if (other.gameObject.tag == "obj")   //cleaner obj(눈송이, 코코아, 해 아이템)와 충돌 시
        {
            Destroy(other.gameObject);  //cleaner 제거
        }

        if (other.gameObject.tag == "Enemy")   //cleaner obj(눈송이, 코코아, 해 아이템)와 충돌 시
        {
            Destroy(other.gameObject);  //cleaner 제거
        }

        if (other.gameObject.tag == "Ground")       //눈송이 ground와 충돌 시
        {
            Destroy(this.gameObject);  //cleaner 제거
        }
    }
    

    public void ClearItems()
    {
        print("ClearItems()");
        GameObject cleaner = Instantiate(cleanerFactory);
        cleaner.transform.position = transform.position;


    }
    
}
