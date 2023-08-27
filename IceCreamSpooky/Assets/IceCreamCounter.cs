using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamCounter : MonoBehaviour
{
    
    public int scoopCounter = 0;

    public void IncreaseCounter()
    {
        scoopCounter++;
    }
    public void DecreaseCounter()
    {
        scoopCounter--;
    }

    public void SetCounter(int newCount)
    {
        scoopCounter = newCount;   
    }
    public int GetCounter() 
    {  
        return scoopCounter; 
    }

}
