using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string projectileType;
    public int speed;
    public int damage;
    public float fireRate;

    public Weapon(string type, int spd, int dmg, float rate)
    {
        projectileType = type;
        speed = spd;
        damage = dmg;
        fireRate = rate;
    }

    public string getType()
    {
        return projectileType;
    }
    public int getSpeed()
    {
        return speed;
    }
    public int getDamage()
    {
        return damage;
    }
    public float getFireRate()
    {
        return fireRate;
    }

    
}
