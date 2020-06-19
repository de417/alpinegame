using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    String projectileType = "TestBullet";
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Bullet(String projectileType)
    {
        this.projectileType = projectileType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Player")
        {
            dealDamage(projectileType);
        }
        else if (collision.collider.tag == "Destructable")
        {
            Destroy(collision.gameObject);
        }
        
        Destroy(this.gameObject);
    }

    private void dealDamage(String projectileType)
    {
        Debug.Log("Hit");
    }
}