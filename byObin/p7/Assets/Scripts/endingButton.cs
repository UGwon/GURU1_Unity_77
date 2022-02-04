using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class endingButton : MonoBehaviour
{
    public void returnGame()
    {
        GameManager.Instance.returnGame();
    }

    public void gameOver()
    {
        GameManager.Instance.endGame();
    }
}
