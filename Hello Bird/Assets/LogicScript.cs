using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI Interface 
using UnityEngine.SceneManagement; //Scene Management

public class LogicScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private AudioSource pointDing;
    [SerializeField] private GameObject gameOverScreen;

    public bool isGameOver;
    private int highScore;
    private int playerScore;

    void Start()
    {
        //Display high score
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    [ContextMenu("Add score")]
    public void addScore(int num)
    {
        playerScore += num;
        scoreText.text = playerScore.ToString();
        pointDing.Play();
    }

    public void restartGame()
    {
        //Restarts current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameOver = false;
    }

    public void gameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);

        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public int getScore()
    {
        return playerScore;
    }
}
