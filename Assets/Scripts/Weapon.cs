using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private string projectileType;
    private int speed;
    private int damage;
    private int fireRate;

    public Weapon(string type, int spd, int dmg, int rate)
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
    public int getFireRate()
    {
        return fireRate;
    }
}
