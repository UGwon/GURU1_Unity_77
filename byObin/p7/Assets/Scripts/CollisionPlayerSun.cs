using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerSun : MonoBehaviour
{
    //ΩÃ±€≈Ê
    private static CollisionPlayerSun _instance;

    public static CollisionPlayerSun Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CollisionPlayerSun>();
            }
            return _instance;
        }
    }

    
    public GameObject[] sunOn;
    public GameObject[] sunOff;

    public bool []isOff;
    public bool isFull;

    // Start is called before the first frame update
    void Start()
    {
        isOff[0] = true;
        isOff[1] = true;
        isOff[2] = true;


        isFull = false;
    }

    
    public void TurnOnSun()
    {
        for(int i = 0; i < 3; i++)
        {
            if (isOff[i])
            {
                sunOff[i].SetActive(false);
                sunOn[i].SetActive(true);
                isOff[i] = false;
                break;
            }
        }
        if (!isOff[2])
        {
            isFull = true;
        }
    }

    public void clearSlot()
    {
        for(int i = 0; i < 3; i++)
        {
            sunOff[i].SetActive(true);
            sunOn[i].SetActive(false);
            isOff[i] = true;
        }
        isFull = false;
    }
}
