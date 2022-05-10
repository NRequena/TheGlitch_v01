using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Collider2D myFeetCollider;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();  
        myFeetCollider = GetComponent<Collider2D>();
        myAnimator.SetBool("isJump", false);

    }


    void Update()
    {
        Run();
        Jump();
        FlipSprite();
      
    }


    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
        }

    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);


    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    } 

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
        } 

    }

    private void Jump()
    {
        if(myRigidBody.velocity.y > Mathf.Epsilon)
        { myAnimator.SetBool("isJump", true); }
        else if (myRigidBody.velocity.y == 0f)
        {
            myAnimator.SetBool("isJump", false);
        }

        

    }
}
