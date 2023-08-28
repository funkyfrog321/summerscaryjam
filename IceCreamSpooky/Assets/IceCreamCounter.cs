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

    //Return player's order
    public int[] GetPlayerOrder()
    {
        return iceCreamOrder;
    }

    //Return to default array
    public void resetPlayerOrder()
    {
        Debug.Log("ResetOrder");

        iceCreamOrder[0] = 0;
        iceCreamOrder[1] = 0;
        iceCreamOrder[2] = 0;

        EmptyHand();
        handConeActive.SetActive(false);
        scoopCounter = 0;
    } 

    public void EmptyHand()
    {
        for(int i = handConeActive.transform.childCount-1; i > -1; i--)
        {
            Debug.Log("Delete Scoop");
            Destroy(handConeActive.transform.GetChild(i).gameObject);
        }
    }

}
