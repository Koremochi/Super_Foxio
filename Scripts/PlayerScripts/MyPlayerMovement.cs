using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    bool canMove = true;
    bool isFacingRight = true;

    float horizontalInput = 0f;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] Animator animator;

    Rigidbody2D playerRB;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(canMove)
        {
            Movement();
            Jump();
            Flip();
        }
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontalInput * speed, playerRB.velocity.y);
        animator.SetFloat("Speed", MathF.Abs(horizontalInput));
    }

    void Movement()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        //if(Input.GetKey(KeyCode.A))
        //{
        //    horizontalInput = -1;
        //}

        //if(Input.GetKey(KeyCode.D))
        //{
        //    horizontalInput = 1;
        //}

        //if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    horizontalInput = 0;
        //}
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
            animator.SetBool("isJumping", true);
            StartCoroutine(WaitForLongJump());
        }

        if(Input.GetKeyUp(KeyCode.Space) && playerRB.velocity.y > 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y / 2.5f);
            animator.SetBool("isJumping", true);
            StartCoroutine(WaitForShortJump());
        }
    }

    IEnumerator WaitForShortJump()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isJumping", false);
    }

    IEnumerator WaitForLongJump()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isJumping", false);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    {
        if((isFacingRight && horizontalInput < 0) || (!isFacingRight && horizontalInput > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public int FaceDirection()
    {
        if(isFacingRight)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
