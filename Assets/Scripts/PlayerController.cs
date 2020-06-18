using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    public enum State { idle, running, jumping, falling}
    public State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 2f;

    public int numSpaceshipParts = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Animation = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if( hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
            state = State.jumping;
        }

        VelocityState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            numSpaceshipParts++;
        }
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {
            if (rb.velocity.y < 0.1) 
            {
                state = State.falling;
            }
        }

        if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > .2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
