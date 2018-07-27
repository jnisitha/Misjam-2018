using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAnimationBody : MonoBehaviour {

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.Play("Falling");
        }
    }
}
