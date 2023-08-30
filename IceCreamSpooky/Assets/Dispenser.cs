using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dispenser : MonoBehaviour
{
    Animator animator;
    private float dispenseDelay = 0.6f;
    private float timeOfLastDispense;

    public ChooseIceCream chooseVanilla;
    public ChooseIceCream chooseChocolate;
    public ChooseIceCream chooseStrawberry;

    public GameObject handConeActive;
    private IceCreamCounter iceCreamCounter;

    public void Dispense(ChooseIceCream.IceCreamFlavor flavor)
    {
        // Don't dispense until the last dispense is finished
        if (Time.time - timeOfLastDispense < dispenseDelay || iceCreamCounter.GetCounter() > 2 || !handConeActive.activeSelf)
        {
            return;
        }
        timeOfLastDispense = Time.time;

        Debug.Log("Dispense " + flavor + "!");
        // Set the trigger on the animator corresponding to the proper flavor
        animator.SetTrigger(ChooseIceCream.IceCreamFlavorString(flavor));

        StartCoroutine(DelayedDispense(flavor));
    }

    IEnumerator DelayedDispense(ChooseIceCream.IceCreamFlavor flavor)
    {
        yield return new WaitForSeconds(dispenseDelay);
        switch (flavor)
        {
            case ChooseIceCream.IceCreamFlavor.Vanilla:
                chooseVanilla.spawnIceCream();
                break;
            case ChooseIceCream.IceCreamFlavor.Chocolate:
                chooseChocolate.spawnIceCream();
                break;
            case ChooseIceCream.IceCreamFlavor.Strawberry:
                chooseStrawberry.spawnIceCream();
                break;
            default:
                Debug.LogError("Invalid ice cream flavor");
                break;
        }   
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timeOfLastDispense = 0f;
        iceCreamCounter = FindObjectOfType<IceCreamCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
