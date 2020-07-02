using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    int timeToMove = 5;
    int timeToShoot = 3;
    bool playerIsInRange = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsInRange){
            Shoot();
        }
    }

    private void Shoot()
    {
        throw new NotImplementedException();
    }
}
