using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //general variables
    private Rigidbody2D rb;
    //private Animator anim;
    public enum State { idle, running, jumping, falling}
    public State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;

    //variables for player Inventory
    [SerializeField] private float speed = 2f;
    public int numSpaceshipParts = 0;

    //player variables
    public int health = 300;

    //variables for weapons and shooting
    public Weapon rangedWeapon = new Weapon("Pistol", 5, 10, 0);
    public Transform firePosition;
    public GameObject bulletPrefab;
    private float timeToFire = 0;
	
	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Animation = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rangedWeapon = new Weapon("Pistol", 5, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
		//Gives Player its animations 
		animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

		//other stuff
		
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0,0,0);
            numSpaceshipParts = 0;
        }

        float hDirection = Input.GetAxis("Horizontal");

        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            //transform.localScale = new Vector2(-1, 1);
        }
        else if(hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //transform.localScale = new Vector2(1, 1);
        }

        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 12f);
            state = State.jumping;
        }

        VelocityState();

        if (rangedWeapon.getFireRate() == 0)
        {
            if (Input.GetButtonDown("Fire1")) //&& inventory.myStuff.bullets > 0)
            {
                ShootWeapon();
            }
            
        }
        else 
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire) // && inventory.myStuff.bullets > 0)
            {
                timeToFire = Time.time + (1 / rangedWeapon.getFireRate());
                ShootWeapon();
            }
        }

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
        if(state == State.jumping || rb.velocity.y > 1)
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
        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
            //rb.velocity = new Vector2(0, 0);
        }
    }

    private void ShootWeapon()
    {
        Debug.Log("pew");
        GameObject bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as GameObject;
        //inventory.myStuff.bullets--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyBullet")
        {
            health -= 10;
        }
        if (health <= 0)
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject);
        }
       
    }

}
