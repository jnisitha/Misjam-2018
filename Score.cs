using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int scoreValue; //current player score
    public int scoreMulti; //score multiplayer based on the height of the bar the character is holding
    public int pointValue = 5;

    public GameObject Bar;

    // For saving and clearing Highscore
    public bool gameOver;
    public bool clearHighscore;

    Text ScoreText;

    private void Awake()
    {
        gameOver = false;
        clearHighscore = false;
        ScoreText = GetComponent<Text>();
        //Debug.Log("highscore=" + getHighScore());
    }

    void FixedUpdate ()
    {
        scoreMulti = Bar.GetComponent<BarHeight>().scoreMultiplier;
        scoreValue += pointValue*scoreMulti;

        ScoreText.text = "Score: " + scoreValue + " x" + scoreMulti;
        //Debug.Log("current Score=" + scoreValue);

	}



    public int getHighScore()
    {
    int highScore = 0;
    if(PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        return highScore;
    }

    public void setHighScore(int currentScore)
    {
        int highScore = getHighScore();
        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
            Debug.Log("New highscore " + currentScore +" saved");
        }
    }

    public void clearHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
            Debug.Log("Highscore cleared");
        }
    }
}
