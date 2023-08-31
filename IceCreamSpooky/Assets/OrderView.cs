using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OrderView : MonoBehaviour
{
    //Get the first order from here
    public PointOfSale pointOfSale;

    Queue<int[]> ListOfOrders = new Queue<int[]>();
    public bool orderIsDisplayed = false;

    public GameObject[] flavors;
    Vector3[] spawnLocations = new Vector3[3];
    public Transform[] scoopLocations;
    public Transform newParent;

    // Using a list instead of a parent to track flavors for destruction
    private List<GameObject> displayedFlavors = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Use local positions instead - this might not end up getting used anyway
        spawnLocations[0] = scoopLocations[0].transform.localPosition;
        spawnLocations[1] = scoopLocations[1].transform.localPosition;
        spawnLocations[2] = scoopLocations[2].transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildQueue(int[] order)
    {
        ListOfOrders.Enqueue(order);
        Debug.Log("Added order: " + OrderToString(order));
    }

    string OrderToString(int[] order)
    {
        string orderString = "";
        for (int i = 0; i < order.Length; i++)
        {
            int item = order[i];
            switch (item)
            {
                case 0:
                    continue;
                case 1:
                    orderString += "vanilla, ";
                    break;
                case 2:
                    orderString += "chocolate, ";
                    break;
                case 3:
                    orderString += "strawberry, ";
                    break;
            }
        }

        orderString += "[" + order[0] + order[1] + order[2] + "]";

        return orderString;
    }

    public void DisplayOrder()
    {
        ClearDisplayOrder();

        if (ListOfOrders.Count > 0)
        {
            AudioManager.instance.PlaySound(2);
            orderIsDisplayed = true;

            int[] currentOrder = ListOfOrders.Dequeue();
            Debug.Log("Displaying order: " + OrderToString(currentOrder));
            for (int i = 0; i <= currentOrder.Length - 1; i++)
            {
                if (currentOrder[i] > 0)
                {
                    //Spawn in Ice Cream on top of location of i scoop.
                    //Debug.Log("i:" + i + ", currentOrder[i]:" + currentOrder[i] + ", flavors[currentOrder[i]]:" + flavors[currentOrder[i] - 1] + ", spawnLocations[i]:" + spawnLocations[i]);
                    GameObject newIceCream = Instantiate(flavors[currentOrder[i] - 1],
                                                         spawnLocations[i],
                                                         Quaternion.identity);

                    // Changing things up: parent to the scoop location. Add to a list for destruction
                    newIceCream.transform.SetParent(scoopLocations[i]);
                    newIceCream.transform.localPosition = new Vector3(0, 0, 0);
                    displayedFlavors.Add(newIceCream);
                }
            }
        }
    }

    public void ClearDisplayOrder()
    {
        orderIsDisplayed = false;
        foreach (GameObject flavorDisplay in displayedFlavors)
        {
            Destroy(flavorDisplay);
        }
        // Clear the list
        displayedFlavors = new List<GameObject>();
    }

}
