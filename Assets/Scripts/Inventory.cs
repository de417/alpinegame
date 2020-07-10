using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public class Items
    {
        public int bullets;
        public int parts;
        public int jetpack;

        public Items(int b, int p, int j)
        {
            bullets = b;
            parts = p;
            jetpack = j;
        }
        
        public Items()
        {
            bullets = 1;
            parts = 1;
            jetpack = 1;
        }
        

    }
    public Items currentItems = new Items(30, 0, 0);
}
