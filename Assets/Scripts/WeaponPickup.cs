using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public Weapon myWeapon;
    // Start is called before the first frame update
    void Start()
    {
        myWeapon = gameObject.AddComponent<Weapon>() as Weapon;
		myWeapon.projectileType = "SMG";
		myWeapon.speed = 10;
		myWeapon.damage = 5;
		myWeapon.fireRate = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerController Player = collision.collider.GetComponent<PlayerController>();
            Player.rangedWeapon = myWeapon;
            Destroy(this.gameObject);
        }
    }
}
