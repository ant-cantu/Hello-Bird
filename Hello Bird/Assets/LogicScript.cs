using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI Interface 
using UnityEngine.SceneManagement; //Scene Management

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public bool isGameOver;

    public GameObject gameOverScreen;

    [ContextMenu("Add score")]
    public void addScore(int num)
    {
        playerScore += num;
        scoreText.text = playerScore.ToString();
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
    }
}
