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
    [SerializeField] private Button menuButton;

    public bool isGameOver = false;
    private int highScore;
    private int playerScore;

    private PipeSpawnScript pipeSpawnScript;

    void Start()
    {
        menuButton.onClick.AddListener(mainMenu);
        
        // Get pipe spawn script
        pipeSpawnScript = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<PipeSpawnScript>();

        // Set current user high score
        highScore = PlayerPrefs.GetInt("highScore");

        //Display high score
        highScoreText.text = "High Score: " + highScore;
    }

    [ContextMenu("Add score")]
    public void addScore(int num)
    {
        playerScore += num;
        scoreText.text = playerScore.ToString();
        pointDing.Play();
        pipeSpawnScript.checkLevel();
    }

    public void restartGame()
    {
        //Restarts current scene/game
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

    public void mainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public int getScore()
    {
        return playerScore;
    }
}
