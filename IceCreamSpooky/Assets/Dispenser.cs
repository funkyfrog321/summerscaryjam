using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour, IInteractable
{
    Animation animation;

    public void Interact()
    {
        Debug.Log("Dispense!");
        animation.Play("Dispense");
    }

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
