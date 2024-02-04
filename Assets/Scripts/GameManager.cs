using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public int lives;
    public Text scoreText;
    public Text livesText;
    public bool gameOver;
    public GameObject gameOverPanel;



    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives:" + lives;
        scoreText.text = "score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Updatelives(int changeInLives)
    {
        lives += changeInLives;


        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives:" + lives;

    }
    public void Updatescore(int points)
    {
        score += points;

        scoreText.text = "score:" + score;
    }
     void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive (true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application is Closed");
    }
}
