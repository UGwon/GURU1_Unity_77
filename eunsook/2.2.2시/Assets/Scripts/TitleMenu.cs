using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] GameObject goManualUI = null;
    public void BtnManual()
    {
        goManualUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
