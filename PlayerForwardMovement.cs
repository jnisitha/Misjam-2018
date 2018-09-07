using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour {

    public float startSpeed = 5.0f;
    public float rotationSpeed = 2.0f; //public float rightRotationSpeed = 2.0f;
    public float slowDownFactor = 0.75f;
    public float speedUpFactor = 1.5f;
    //public float jumpSpeed = 15.0f;
    //public float jumpTime = 0.01f;
    public Vector3 constantVelocity = new Vector3(10, 0, 0);
    public Vector3 currentVelocity = new Vector3(0,0,0);
    //public Vector3 acceleration = new Vector3(3, 0, 0);

    public bool playerStart;
    public Game_Manager game_Manager;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerStart = game_Manager.playerStart;
        if (playerStart)
        {
            currentVelocity = constantVelocity;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                currentVelocity = constantVelocity * speedUpFactor;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                currentVelocity = constantVelocity * slowDownFactor;
            }

            this.GetComponent<Rigidbody>().velocity = currentVelocity;
        }
        else{}
        //JUMP
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    this.transform.Translate(new Vector3(0, jumpSpeed * jumpTime, 0));
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            game_Manager.playerWin = true;
            game_Manager.levelEnd();
        }
    }
}
