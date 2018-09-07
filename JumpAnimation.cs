using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimation : MonoBehaviour {

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jumping");
            Debug.Log("Pressed Space");
            
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            animator.Play("Fall");
            Debug.Log("Pressed f");

        }


        //else
        //{
        //    animator.Play("Idle");
        //}
    }
}
