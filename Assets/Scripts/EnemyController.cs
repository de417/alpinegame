using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    float timeToMove = 4f;
    float timeToShoot = 3;
    int direction = 1;
    public float speed = 1/100;
    public bool playerIsInRange = false;
    public GameObject player;
    public int health = 100;

    public Transform firePosition;
    public GameObject bulletPrefab;
    // Start is called before the first frame update

   
	
	//AnimationTest
	public Animator animator;
	

    // Update is called once per frame
    void Update()
    {
// Updated upstream
		animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

// Stashed changes
		
        if((Math.Abs(transform.position.x - player.transform.position.x) < 7) && Math.Abs(transform.position.y - player.transform.position.y) < 7)
        {
            playerIsInRange = true;
        }
        else
        {
            playerIsInRange = false;
        }

        if(Time.time > timeToMove)
        {
            direction *= -1;
            timeToMove = Time.time + 4f;
        }
        transform.position = new Vector3 (transform.position.x + (speed * direction), transform.position.y, transform.position.z);

        if(playerIsInRange){
            Shoot();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerBullet")
        {
            health -= 10;
            Debug.Log("Ouch");
        }
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void Shoot()
    {
        Debug.Log("Attack!");

        Vector3 Difference;
        float rotationZ;
        Difference = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.z); //calculates difference between player location and mouse location
        Difference.Normalize(); //sets magnitude to 1 while maintaining component ratios
        rotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg; //finds angle in degrees
        //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        

        if (Time.time > timeToShoot) 
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, firePosition.position, Quaternion.Euler(Difference)) as GameObject;
            timeToShoot = Time.time + 3f;
        }
        

    }
}
