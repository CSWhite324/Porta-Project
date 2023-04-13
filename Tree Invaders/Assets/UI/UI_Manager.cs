using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public bool isVisible = true;
    public bool isStarted = false;
    public Text title;
    public Text highScoreText;
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    private float score = 0;
    private float highscore = 0;
    private bool firstKill;
    public static UI_Manager instance;
    public bool move = true;

    private void Awake()
    {
        move = true;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        highScoreText.text = highscore.ToString();
        instance = this;
        firstKill = true;
        scoreText.text = "000.00";
        score = 1;
        gameOverText.enabled = false;   
        restartText.enabled = false;
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
            highScoreText.enabled = false;
            gameOverText.enabled = false;
            restartText.enabled = false;

        }
        else
        {
            title.enabled = true;
            highScoreText.enabled = true;
        }

        if (score <= 0)
        {
            gameOver();
            if(move == false && Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            move = true;
        }
    }

    public void addScore()
    {
        if(firstKill)
        {

            firstKill = false;
            score = 4f;
            scoreText.text =  score.ToString();
        }
        else
        {
            score += 3;
            scoreText.text = "" + score.ToString();
        }
        if (highscore < score)
        {
            PlayerPrefs.SetFloat("highscore", score);
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
            score += 0.01f;
            scoreText.text = "" + score;
            yield return new WaitForSeconds(1);
        }
    }

    public void gameOver()
    {
        gameOverText.enabled = true;
        highScoreText.enabled = true;
        title.enabled = true;
        restartText.enabled = true;
        move = false;
    }
}
