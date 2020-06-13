using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class cameraShift : MonoBehaviour
{
    public GameObject player;
    move playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<move>();
    }

    // Update is called once per frame
    void Update()
    {
        // doesn't really work
        if ((player.transform.position.x - transform.position.x) > 3 || (transform.position.x - player.transform.position.x) > 6)
        {
            if (playerScript.isMoving)
                transform.Translate(new Vector2(playerScript.speed, 0));
            else
            {
                if (player.transform.position.x > transform.position.x)
                {
                    transform.Translate(new Vector2(0.3f, 0));
                }
                else
                {
                    transform.Translate(new Vector2(-0.3f, 0));
                }
            }
        }
    }

}
