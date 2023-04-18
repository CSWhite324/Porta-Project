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
    [SerializeField] Text highScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    [SerializeField] Text restartText;
    [SerializeField] Text soundText;
    [SerializeField] Text gamePlayText;
    [SerializeField] Text particleText;
    [SerializeField] Text explosionsText;
    [SerializeField] Text instructionsText;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle explosionsToggle;
    public float score = 0f;
    private float highscore = 0;
    public bool firstKill = true;
    public static UI_Manager instance;
    public bool move = true;
    public int pause = 1;

    private void Awake()
    {
        move = true;
        pause = 1;
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
        soundText.enabled = false;
        gamePlayText.enabled = false;
        particleText.enabled = false;
        explosionsText.enabled = false;
        instructionsText.enabled = false;
        volumeSlider.gameObject.SetActive(false);
        explosionsToggle.gameObject.SetActive(false);
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

        if (score < 0)
        {
            gameOver();
            move = false;   
            if(move == false && Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if(pause == 1)
        {
            move = true;
        }
        

        if (Input.GetMouseButtonDown(1))
        {
            paused();
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

    public void paused()
    {
        pause *= -1;
        if (pause == -1)
        {
            soundText.enabled = true;
            gamePlayText.enabled = true;
            particleText.enabled = true;
            explosionsText.enabled = true;
            instructionsText.enabled = true;
            volumeSlider.gameObject.SetActive(true);
            explosionsToggle.gameObject.SetActive(true);
            move = false;
        }
        if(pause == 1)
        {
            soundText.enabled = false;
            gamePlayText.enabled = false;
            particleText.enabled = false;
            explosionsText.enabled = false;
            instructionsText.enabled = false;
            volumeSlider.gameObject.SetActive(false);
            explosionsToggle.gameObject.SetActive(false);
            move = true;
        }
    }
}
