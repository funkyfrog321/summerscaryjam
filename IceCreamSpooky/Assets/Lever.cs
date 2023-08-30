using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField]
    public ChooseIceCream.IceCreamFlavor myFlavor;
    Dispenser dispenser;
    public void Interact()
    {
        dispenser.Dispense(myFlavor);
    }

    // Start is called before the first frame update
    void Start()
    {
        dispenser = transform.parent.GetComponent<Dispenser>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
