using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool isMoving;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
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
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal != 0)
        {
            isMoving = true;
            if (isGrounded())
            {
                speed = moveHorizontal * 0.04f;
                transform.Translate(new Vector2(speed, 0));
            }

            else
            {
                speed = moveHorizontal * 0.03f;
                transform.Translate(new Vector2(moveHorizontal * 0.02f, 0));
            }

        }

        else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown("space"))
        {
            if (isGrounded()) {
                rb.AddForce(new Vector2(0, 10.0f), ForceMode2D.Impulse);
            }
        }


    }


}
