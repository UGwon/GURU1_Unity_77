using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowManager : MonoBehaviour
{
    private static RainbowManager _instance;

    public static RainbowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RainbowManager>();
            }
            return _instance;
        }
    }

    private Rigidbody2D rigidbody;
    float currentTime;
    float timer=3;
    public float waitingTime;
    public GameObject rainbowFactory;
    float createTime;

    public bool FeverOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

 
    // Update is called once per frame
    void Update()
    {
       
      

    }
    
    
        /*while (currentTime < timer)
        {
            if (createTime > waitingTime)
            {
                GameObject rainbow = Instantiate(rainbowFactory);
                rainbow.transform.position = transform.position;
                createTime = 0;
            }
        }*/



    

   
}
