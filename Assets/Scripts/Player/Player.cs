using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7.5f;

    [SerializeField] float jumpPower = 8.0f;
    [SerializeField] float jumpTime = 0.5f;

    [SerializeField] float extraHeight = 0.25f;
    [SerializeField] LayerMask whatIsGround;

    Rigidbody2D rigid;
    Animator anim;
    Collider2D coll;

    bool isFacingRight = false;
    bool isJumping;
    bool isFalling;

    RaycastHit2D groundHit;

    float jumpTimeCounter;

    Coroutine resetTrigger;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontal = InputUser.Instance.moveInput.x;

        if (Math.Abs(horizontal) > 0)
        {
            anim.SetBool("isWalking", true);
            TurnCheck();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        rigid.velocity = new Vector2(horizontal * moveSpeed, rigid.velocity.y);
    }

    #region Flip
    private void TurnCheck()
    {
        if (InputUser.Instance.moveInput.x > 0 && !isFacingRight)
        {
            Turn();
        }
        else if (InputUser.Instance.moveInput.x < 0 && isFacingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = false;
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = true;
        }
    }
    #endregion

    private void Jump()
    {
        if (InputUser.Instance.control.Jumping.Jump.WasPerformedThisFrame() && isGrounded())
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }

        if (InputUser.Instance.control.Jumping.Jump.IsPressed())
        {
            if (jumpTimeCounter > 0 && isJumping)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                jumpTimeCounter -= Time.deltaTime;
            }
            else if (jumpTimeCounter <= 0)
            {
                isJumping = false;
                isFalling = true;
            }
            else
            {
                isJumping = false;
            }
        }

        if(InputUser.Instance.control.Jumping.Jump.WasReleasedThisFrame())
        {
            isJumping = false;
            isFalling = true;
        }
        DrawGroundCheck();
    }

    private bool CheckForLand()
    {
        if (isFalling)
        {
            if (isGrounded())
            {
                isFalling = false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isGrounded()
    {
        groundHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, extraHeight, whatIsGround);

        if (groundHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #region Debug Function

    private void DrawGroundCheck()
    {
        Color rayColor;

        if (isGrounded())
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(coll.bounds.center + new Vector3
            (coll.bounds.extents.x, 0), Vector2.down * (coll.bounds.extents.y + extraHeight), rayColor);

        Debug.DrawRay(coll.bounds.center - new Vector3
            (coll.bounds.extents.x, 0), Vector2.down * (coll.bounds.extents.y + extraHeight), rayColor);

        Debug.DrawRay(coll.bounds.center - new Vector3(
            coll.bounds.extents.x, coll.bounds.extents.y + extraHeight),
            Vector2.right * (coll.bounds.extents.x * 2), rayColor);
    }

    #endregion
}
