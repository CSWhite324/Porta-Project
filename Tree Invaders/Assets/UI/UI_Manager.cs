using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public bool isVisible = true;
    public bool isStarted = false;
    public Text title;
    public Text highScore;
    public Text scoreText;
    private double score;
    private bool firstKill;
    public static UI_Manager instance;

    private void Start()
    {
        instance = this;
        firstKill = true;
        scoreText.text = "000.00";
        score = 0;
    }
    private void Update()
    {
        if (!isVisible)
        {
            if (!isStarted)
            {
                StartCoroutine(timeScore());
                isStarted = true;
            }
            title.enabled = false;
            highScore.enabled = false;

        }
        else
        {
            title.enabled = true;
            highScore.enabled = true;
        }
    }

    public void addScore()
    {
        if(firstKill)
        {

            firstKill = false;
            score = 4;
            scoreText.text =  "" + score;
        }
        else
        {
            score += 3;
            scoreText.text = "" + score;
        }
    }

    public void subScore()
    {
        score -= 1;
        scoreText.text = "" + score;
    }

    IEnumerator timeScore()
    {
        while (true)
        {
            score += 0.01;
            scoreText.text = "" + score;
            yield return new WaitForSeconds(1);
        }
    }
}
