using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class cameraShift : MonoBehaviour
{
    public Transform player;
    move playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

}
