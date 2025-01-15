using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 7.5f;

    Rigidbody2D rigid;
    Animator anim;

    bool isFacingRight = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        //Jump();
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
        throw new NotImplementedException();
    }
}
