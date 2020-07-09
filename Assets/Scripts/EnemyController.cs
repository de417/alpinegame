using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    float timeToMove = 4f;
    int timeToShoot = 3;
    int direction = 1;
    public float speed = 1/100;
    public bool playerIsInRange = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    private void Shoot()
    {
        Debug.Log("Attack!");
    }
}
