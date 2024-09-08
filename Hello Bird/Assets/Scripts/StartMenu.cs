using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("highScore");

        // Start button click listener
        startButton.onClick.AddListener(startGame);
        resetButton.onClick.AddListener(resetScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void resetScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        highScore.text = "High Score: " + 0;
    }
}
