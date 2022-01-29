using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] GameObject Select= null;
    public void Swuribut()
    {
        Select.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Wendybut()
    {
        Select.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Usibut()
    {
        Select.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
