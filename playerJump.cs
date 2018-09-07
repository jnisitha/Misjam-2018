using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour {

    private float playerStartY;
    private bool isJumpPressed = false;
    public Vector3 gravityVector = new Vector3(0f, -10f, 0f);
    public Vector3 jumpVector =  new Vector3(0f, 7f, 0f);
    Rigidbody rb;
    public bool ifGrounded;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ifGrounded = true;
        playerStartY = gameObject.transform.localPosition.y;
    }

    void Update()
    {
        //inputJump();
    }

    void FixedUpdate()
    {
        // Debug.Log(Physics.gravity);
        //rb.AddForce(gravityVector, ForceMode.Acceleration);
        //jump();
        setGroundedConditions();
    }

    void inputJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ifGrounded)
        {
            isJumpPressed = true;  // User pressed jump
        }
    }

    void jump(){
        if(isJumpPressed){
            isJumpPressed = false;
            gameObject.GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.Impulse);
        }
    }

    void setGroundedConditions(){
        Vector3 pos = gameObject.transform.localPosition;
        if(pos.y <= playerStartY){
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            gameObject.transform.localPosition = new Vector3(pos.x, playerStartY, 0.0f);
            ifGrounded = true;
        }
        else{
            ifGrounded = false;
        }
    }
}
