using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractable
{

    public IceCreamCounter iceCreamCounter;

    public void Interact()
    {
        iceCreamCounter.EmptyHand();

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
