using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseIceCream : MonoBehaviour, IInteractable
{

    public GameObject iceCreamScoop;
    public Transform parentChange;
    public Vector3 spawnPoint;
    public GameObject handConeActive;

    public void Interact()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void spawnIceCream()
    {
        if(handConeActive.activeSelf == true)
        {
            Debug.Log("Scoop Ice Cream");
            GameObject newIceCream = Instantiate(iceCreamScoop, spawnPoint, Quaternion.identity);
            newIceCream.transform.SetParent(parentChange);
        }
    }

}
