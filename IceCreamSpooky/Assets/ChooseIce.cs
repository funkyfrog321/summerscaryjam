using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class ChooseIceCream : MonoBehaviour, IInteractable
{
    //Ice Cream Scoop GameObject
    public GameObject iceCreamScoop;

    //Public Counter Class
    private IceCreamCounter iceCreamCounter;

    //Parent the ice creams to the player cam
    public Transform parentChange;

    //Locations of where the ice cream will spawn.
    public Vector3 spawnPoint1;
    public Vector3 spawnPoint2;
    public Vector3 spawnPoint3;

    //Locations of the different scoops
    public Transform scoop1Location;
    public Transform scoop2Location;
    public Transform scoop3Location;

    public GameObject handConeActive;



    public void Interact()
    {
        spawnIceCream();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        iceCreamCounter = FindObjectOfType<IceCreamCounter>();
    }

    void spawnIceCream()
    {

        if(iceCreamCounter.GetCounter() == 0 && handConeActive.activeSelf == true) {
            
           Debug.Log("Scoop Ice Cream");
            
           //Gain Location of 1st scoop
           spawnPoint1 = scoop1Location.transform.position;
            
           //Spawn in Ice Cream on top of location of first scoop.
           GameObject newIceCream = Instantiate(iceCreamScoop, spawnPoint1, Quaternion.identity);

           //Parent the new ice cream scoop to the player character so that it moves with cone.
           newIceCream.transform.SetParent(parentChange);

           iceCreamCounter.IncreaseCounter();
     
        }
        else if (iceCreamCounter.GetCounter() == 1 && handConeActive.activeSelf == true)
        {
            Debug.Log("Scoop Ice Cream 2");

            //Gain Location of 2st scoop
            spawnPoint2 = scoop2Location.transform.position;

            //Spawn in Ice Cream on top of location of second scoop.
            GameObject newIceCream = Instantiate(iceCreamScoop, spawnPoint2, Quaternion.identity);

            //Parent the new ice cream scoop to the player character so that it moves with cone.
            newIceCream.transform.SetParent(parentChange);

            iceCreamCounter.IncreaseCounter();
        }
        else if (iceCreamCounter.GetCounter() == 2 && handConeActive.activeSelf == true)
        {
            Debug.Log("Scoop Ice Cream 3");

            //Gain Location of 3rd scoop
            spawnPoint3 = scoop3Location.transform.position;

            //Spawn in Ice Cream on top of location of third scoop.
            GameObject newIceCream = Instantiate(iceCreamScoop, spawnPoint3, Quaternion.identity);

            //Parent the new ice cream scoop to the player character so that it moves with cone.
            newIceCream.transform.SetParent(parentChange);

            iceCreamCounter.IncreaseCounter();
        }
        else if (iceCreamCounter.GetCounter() > 2)
        {
            Debug.Log("Ice Cream too big!");
        }
    }

}
