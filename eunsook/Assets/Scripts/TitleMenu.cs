using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] GameObject goSelectUI = null;
    public void selectbut()
    {
        goSelectUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    [SerializeField] GameObject goManualUI = null;
    public void manualbut()
    {
        goManualUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}