using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyIceCream : MonoBehaviour
{
    public int[] iceCream = { 0, 0, 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIceCream();
    }

    public Boolean checkIceCream()
    {
        if (iceCream[1] > 0)
        {
            return false;
        }
        else if (iceCream[2] > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
