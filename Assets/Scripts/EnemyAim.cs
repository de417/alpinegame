using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{

    public int rotationOffset = 90;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Difference = player.transform.position - transform.position; //calculates difference between player location and mouse location
        Difference.Normalize(); //sets magnitude to 1 while maintaining component ratios
        float rotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg; //finds angle in degrees
        transform.rotation = Quaternion.Euler(Difference);
    }
}
