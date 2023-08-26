using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseanIceCream : MonoBehaviour, IInteractable
{

    public GameObject coneInHand;
    public GameObject flavor;
    
    public GameObject player;

    public GameObject scoop1, scoop2, scoop3;

    public Transform scoop1place, scoop2place, scoop3place;

    public void Interact()
    {
        
        if(coneInHand.activeSelf == true)
        {
            Debug.Log("Scoops ice cream");
            
            //Takes a parent ice cream object and clones it
            GameObject newObj = GameObject.Instantiate(flavor, scoop1place) as GameObject;
            flavor.transform.parent = scoop1.transform.parent;

            //grab coordinates of scoop1 to pass on to flavor


            //takes away the placeholder first scoop
            GameObject.Instantiate(flavor, scoop1place);
            GameObject.DestroyImmediate(scoop1);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(flavor, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
