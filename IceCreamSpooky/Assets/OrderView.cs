using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderView : MonoBehaviour
{
    //Get the first order from here
    public PointOfSale pointOfSale;

    Queue<int[]> ListOfOrders = new Queue<int[]>();

    public GameObject[] flavors;

    public Vector3[] spawnLocations;

    public Transform[] scoopLocations;

    public Transform newParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildQueue(int[] order)
    {
        ListOfOrders.Enqueue(order);
    }

    public void DisplayOrder()
    {
        spawnLocations[0] = scoopLocations[0].transform.position;
        spawnLocations[1] = scoopLocations[1].transform.position;
        spawnLocations[2] = scoopLocations[2].transform.position;
        int[] currentOrder = ListOfOrders.Dequeue();

        for(int i = 0; i <= currentOrder.Length -1; i++)
        {
            if (currentOrder[i] > 0)
            {
                Debug.Log(currentOrder[i]);
                //Spawn in Ice Cream on top of location of i scoop.
                GameObject newIceCream = Instantiate(flavors[currentOrder[i]],
                                                     spawnLocations[i],
                                                     Quaternion.identity);

                //Parent the new ice cream scoop to the player character so that it moves with cone.
                newIceCream.transform.SetParent(newParent);
            }
            
        }
    }

    public void ClearDisplayOrder()
    {
        for (int i = newParent.transform.childCount - 1; i > -1; i--)
        {
            Debug.Log("Delete Scoop");
            Destroy(newParent.transform.GetChild(i).gameObject);
        }
    }

}
