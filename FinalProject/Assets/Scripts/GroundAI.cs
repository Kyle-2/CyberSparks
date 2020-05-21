using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAI : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;

    public float jumpForce;

    public GameObject Player;

    public bool isLeft = false;
    public Transform isLeftChecker;
    public Transform isRightChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckIfGrounded();
        CheckIfAttacking();
    }

    private void CheckIfAttacking()
    {
        Collider2D collider = Physics2D.OverlapCircle(isLeftChecker.position, checkGroundRadius, playerLayer);

        if (collider != null)
        {
            isLeft = false;
            Player.GetComponent<Health>().Dammage();
        }
        else
        {
            collider = Physics2D.OverlapCircle(isRightChecker.position, checkGroundRadius, playerLayer);
            if (collider != null)
            {
                isLeft = true;
                Player.GetComponent<Health>().Dammage();
            }
        }
    }

    void Move()
    {
        float x = 1;
        if(isLeft)
        {
            x *= -1;
        }
        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isLeftChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isLeft = false;
        }
        else
        {
            collider = Physics2D.OverlapCircle(isRightChecker.position, checkGroundRadius, groundLayer);
            if(collider != null)
            {
                isLeft = true;
            }
        }
    }
}
