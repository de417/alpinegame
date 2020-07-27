using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    public int rotationOffset;
    float rotationZ;

    Vector3 Difference;

    // Start is called before the first frame update
    void Start()
    {
        Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //calculates difference between player location and mouse location
        Difference.Normalize(); //sets magnitude to 1 while maintaining component ratios
        rotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg; //finds angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
