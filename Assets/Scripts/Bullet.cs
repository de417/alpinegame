using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public String projectileType = "TestBullet";
    public int speed = 1;
    public int damage = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    public Bullet(String projectileType, int speed, int damage)
    {
        this.projectileType = projectileType;
        this.speed = speed;
        this.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Difference.x >= 0 && Difference.y >= 0)
        {
            transform.position = transform.position + new Vector3((float)Math.Sqrt(Math.Abs(Difference.x)) * speed * Time.deltaTime, (float)Math.Sqrt(Math.Abs(Difference.y)) * speed * Time.deltaTime, 0);
        }else if (Difference.x < 0 && Difference.y > 0)
        {
            transform.position = transform.position + new Vector3((float)Math.Sqrt(Math.Abs(Difference.x)) * -1 * speed * Time.deltaTime, (float)Math.Sqrt(Math.Abs(Difference.y)) * speed * Time.deltaTime, 0);
        }else if (Difference.x < 0 && Difference.y < 0)
        {
            transform.position = transform.position + new Vector3((float)Math.Sqrt(Math.Abs(Difference.x)) * -1 * speed * Time.deltaTime, (float)Math.Sqrt(Math.Abs(Difference.y)) * -1 * speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = transform.position + new Vector3((float)Math.Sqrt(Math.Abs(Difference.x)) * speed * Time.deltaTime, (float)Math.Sqrt(Math.Abs(Difference.y)) * -1 * speed * Time.deltaTime, 0);
        } */

        transform.localPosition = transform.localPosition + new Vector3((float)speed / 100f , 0, 0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Destructable")
        {
            Destroy(collision.gameObject);
        }
        
        Destroy(this.gameObject);
    }

    private void dealDamage(String projectileType, int damage)
    {
        Debug.Log("Hit" + damage);
    }
}