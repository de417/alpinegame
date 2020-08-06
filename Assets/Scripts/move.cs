using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool isMoving;
    public float speed;
    public bool jump;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        jump = false;
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<Collider2D>().bounds.extents.y + 0.1f);

        if (hit.collider != null)
        {
            return true;
        }
        else return false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded() || isAgainstWall() != 0)
            {
                jump = true;
            }
        }




    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        int againstWall = isAgainstWall();

        // standard left/right movement
        if (moveHorizontal != 0)
        {
            isMoving = true;
            if (isGrounded())
            {
                speed = moveHorizontal * 0.15f;
                transform.Translate(new Vector2(speed, 0));
            }

            else
            {
                speed = moveHorizontal * 0.1f;
                transform.Translate(new Vector2(speed, 0));
            }

        }

        else
        {
            isMoving = false;
        }

        // jumping from the ground or from a wall to the left or right
        if (jump)
        {
            switch (againstWall)
            {
                case 0:
                    rb.AddForce(new Vector2(0, 12.0f), ForceMode2D.Impulse);
                    break;
                case 1:
                    rb.AddForce(new Vector2(10.0f, 12.0f), ForceMode2D.Impulse);
                    Debug.Log("jumping right");
                    break;
                case 2:
                    rb.AddForce(new Vector2(-10.0f, 12.0f), ForceMode2D.Impulse);
                    Debug.Log("jumping left");
                    break;
            }
            jump = false;
        }

        if (againstWall != 0)
        {
            rb.gravityScale = 1.5f;
        }
        else
        {
            rb.gravityScale = 3.0f;           
        }

    }

    //checks if player is against a wall
    int isAgainstWall()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, GetComponent<Collider2D>().bounds.extents.y - 0.3f);

        if (left.collider != null)
        {
            return 1;
        }

        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, GetComponent<Collider2D>().bounds.extents.y - 0.3f);

        if (right.collider != null)
        {
            return 2;
        }

        return 0;
    }



}
