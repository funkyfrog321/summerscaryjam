using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamCounter : MonoBehaviour
{
    
    public int scoopCounter = 0;
    public int[] iceCreamOrder = { 0, 0, 0 };
    
    //Take handcone to set inactive after delivered cone
    public GameObject handConeActive;

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

    //For keeping track of what ice cream has been created by the player
    public void insertNewCream(int creamID, int numberScoop)
    {
        iceCreamOrder[numberScoop] = creamID;
    }

    //Return to default array
    public void resetPlayerOrder()
    {
        iceCreamOrder[0] = 0;
        iceCreamOrder[0] = 0;
        iceCreamOrder[0] = 0;

        handConeActive.SetActive(false);
    } 

}
