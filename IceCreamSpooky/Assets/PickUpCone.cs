using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{

    public GameObject playerHand;
    public GameObject itemToHold;


    public void Interact()
    {
        playerHand.SetActive(true);
        Debug.Log("Cone in hand.");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
