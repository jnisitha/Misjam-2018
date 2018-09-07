using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBalance : MonoBehaviour
{

    public GameObject Bar;

    [Range(-50f, 50f)]
    public float currentBalance;     // min -50 - max 50
    public float fallAcceleration;   // higher acceleration when closer to 0 or 100. lower acceleration when closer to 50
    public float difficultyMultiplier;
    private float difficultyTimer;
    public float balanceAcceleration;
    public float accValue = 0.5f;    //player control over tilt

    [Range(10f, 30f)]
    public float barHeight;          // min 10 - max 30
    private float heightScale;

    BarHeight player_bar;

    // public float safeMax;
    // public float safeMin;

    //private float easiest = 30f; // bar at the lowest
    //private float hardest = 10f; // bar at the highest
    public float currentDifficulty;

    private float barMin = -50f;
    private float barMax = 50f;
    private float balenceNum;

    public Game_Manager game_Manager;
    public Animator animator;
    // private float barWidth; // 100

    // Use this for initialization
    void Start ()
    {
        //currentBalance = 0f;
        //fallAcceleration = 0.1f;
        //balanceAcceleration = 0f;
        //barHeight = 20f;
        //calculateCurrentDifficulty();

        setInitialBalanceDifficulty();
    }

    public void setInitialBalanceDifficulty(){
        currentBalance = 0f;
        fallAcceleration = 0.1f;
        difficultyMultiplier = 0.1f;
        difficultyTimer = 1f;
        balanceAcceleration = 0f;
        barHeight = 20f;
        calculateCurrentDifficulty();
        animator.SetBool("Upright", true);
        }

    // Update is called once per frame
    void FixedUpdate ()
    {
        difficultyTimer += Time.deltaTime;
        calculateCurrentDifficulty();
        calculateFallAcceleration();

        if (Input.GetKey(KeyCode.A))
        {
           // Debug.Log("Left key was pressed.");
            balanceAcceleration = -accValue* difficultyMultiplier * difficultyTimer;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Right key was released.");
            balanceAcceleration = accValue* difficultyMultiplier * difficultyTimer;
        }
        else{
            balanceAcceleration = 0f;
        }

        heightScale = Bar.GetComponent<BarHeight>().heightScale;
        barHeight = Mathf.Lerp(30, 10, heightScale);
	}

    // if currentBalance is within safeZone, acceleration increase slower
    // if currentBalance is outside the sazezone acceleration inclease faster
    void calculateFallAcceleration()
    {
        balenceNum = Mathf.Abs(currentBalance);
        // if within the safezone
        if (balenceNum <= currentDifficulty)
        {
           // Debug.Log("within the safezone");
            if (currentBalance >= 0)
            {
                fallAcceleration = 0.1f*difficultyMultiplier*difficultyTimer;
            }
            else
            {
                fallAcceleration = -0.1f*difficultyMultiplier * difficultyTimer;
            }
            updateCurrentBalance();
        }
        // if outside the safezone
        else if(balenceNum >= barMax && game_Manager.playerStart==true)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
            game_Manager.playerWin = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            animator.SetBool("Upright", false);
            animator.Play("Fall");
            game_Manager.levelEnd();
        }
        else {
           // Debug.Log("outside the safezone");
            if (currentBalance >= 0)
            {
                fallAcceleration = 0.5f*difficultyMultiplier * difficultyTimer;
            }
            else
            {
                fallAcceleration = -0.5f* difficultyMultiplier * difficultyTimer;
            }
            
            updateCurrentBalance();
        }
    }

    void updateCurrentBalance()
    {
        // v = u + at
        currentBalance = currentBalance + (fallAcceleration+balanceAcceleration);
        currentBalance = Mathf.Clamp(currentBalance, barMin, barMax);
        //Debug.Log(currentBalance);
    }

    // Lower the barHeight easier to balance the player (ex: safezone isbetween 20-80)
    // heigher the barHeight harder to balance the player (ex: safezone isbetween 40-50)
    void calculateCurrentDifficulty()
    {
        // when barHeight=10f => easiset => currentDifficulty=30f
        // when barHeight=30f => hardest => currentDifficulty=10f
        //float m = -1f;
        currentDifficulty  = barHeight;
        //Debug.Log(currentDifficulty);
    }
}
