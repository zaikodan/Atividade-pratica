using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float moveForce, jumpForce;
    bool onGround;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        rigidbody2D.velocity = new Vector2(moveForce, rigidbody2D.velocity.y);
    }

    void Jump()
    {
        rigidbody2D.velocity = new Vector2 (0, jumpForce);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            moveForce = -5;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            moveForce = 5;
        }
        else
        {
            moveForce = 0;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            jumpForce = 5;
            Jump();
        }

        Move();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            onGround = false;
        }
    }
}
