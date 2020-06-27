using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public Weapon myWeapon = new Weapon("SMG", 10, 5, 5);
    // Start is called before the first frame update
    void Start()
    {
        myWeapon = new Weapon("SMG", 10, 5, 5);
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
