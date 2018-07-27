using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public GameObject startPoint;   //Starting point for the player in each level
    public GameObject endPoint;     //End point of each level
    public GameObject player;
   
    public bool playerStart = false;
    public bool playerWin;
    public float startDelay = 3.0f;
    public Text endMessage;
    public Text highScore;
    public Text startMessage;
    private Text Message;
    public Score playerScore;


    public float playerStartX, playerStartY, playerStartZ; 
    private void Start()
    {
        playerStartX = player.GetComponent<Transform>().position.x;
        playerStartY = player.GetComponent<Transform>().position.y;
        playerStartZ = player.GetComponent<Transform>().position.z;
        //Debug.Log("Start X " + playerStartX + " Start Y " + playerStartY + " Start Z " + playerStartZ);
        levelStart();
    }
    //What I should have done, and didn't was have update fuction in the game manager be cheacking for all the flags.
    //Has a change state condition been met? Instead I had the conditions call the apropreate statechange
    private void Update()
    {
        if (Input.GetKey("escape"))
        { Application.Quit(); }
        if (Input.GetKey(KeyCode.Y))
        { playerScore.clearHighScore(); }
    }

    public void levelStart()
    {
        playerScore.enabled = true;
        playerScore.scoreValue = 0;
        player.transform.position = new Vector3(playerStartX, playerStartY, playerStartZ);
        player.GetComponent<playerBalance>().setInitialBalanceDifficulty();
        StartCoroutine(startPause());
    }

    public void levelEnd()
    {
        //Score
        if (playerScore.scoreValue > playerScore.getHighScore())
        {
            playerScore.setHighScore(playerScore.scoreValue);
        }
        highScore.text = ("High Score: " + playerScore.getHighScore());
        playerScore.enabled = false;

        //End screen Text
        endMessage.GetComponent<Text>().enabled = true;
        foreach (Transform child in endMessage.transform)
        {
            child.gameObject.SetActive(true);
        }
        playerStart = false;
        Message = endMessage.GetComponent<Text>();
        if (playerWin == true)
        {
            Message.text = "You have become one with all";
            playerWin = false;
        }
        else
        {
            Message.text = "We all become one with the cosmos";
        }

        //restart buttion resets the game
    }

    public void Restart()
    {
        endMessage.GetComponent<Text>().enabled = false;
        player.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionX;
        foreach (Transform child in endMessage.transform)
        {
            child.gameObject.SetActive(false);
        }

        levelStart();
    }


    IEnumerator startPause()
    {
        startMessage.GetComponent<Text>().enabled = true;
        yield return new WaitForSecondsRealtime(startDelay);
        startMessage.GetComponent<Text>().enabled = false;
        playerStart = true;
    }
}
