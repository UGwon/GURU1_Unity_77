using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] GameObject TitleMenu = null;
    public void Backbut1()
    {
        TitleMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    [SerializeField] GameObject goPlayUI = null;
    public void Swuribut()
    {
        goPlayUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Wendybut()
    {
        goPlayUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void usibut()
    {
        goPlayUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
