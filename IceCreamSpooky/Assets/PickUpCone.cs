using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCone : MonoBehaviour, IInteractable
{

    public GameObject playerHand;


    public void Interact()
    {
        playerHand.SetActive(true);
        Debug.Log("Cone in hand.");
    }


}