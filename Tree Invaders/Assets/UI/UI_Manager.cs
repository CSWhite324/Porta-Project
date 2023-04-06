using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public bool isVisible = true;
    public Text title;
    public Text highScore;
    public static UI_Manager instance;

    private void Start()
    {
        instance = this;    
    }
    private void Update()
    {
        if (!isVisible)
        {
            title.enabled = false;
            highScore.enabled = false;
        }
        else
        {
            title.enabled = true;
            highScore.enabled = true;
        }
    }

    public void gameStart()
    {
        isVisible = false;
    }
}
