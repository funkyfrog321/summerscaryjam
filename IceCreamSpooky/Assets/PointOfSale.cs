using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PointOfSale : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    BackOfTheLine backOfTheLine;
    // Notify nav agents that the back of the line has moved
    public event EventHandler BackOfTheLineMoved;

    public IceCreamCounter playerOrderPosition;

    public OrderView orderView;

    public GameTimer gameTimer;

    Queue<NPC> NPCsInLine = new Queue<NPC>();


    public int[] currentCustomerOrder;

    public void Interact()
    {
        //TODO: double check this
        if (NPCsInLine.Count == 0)
        {
            orderView.ClearDisplayOrder();
            return;
        }

        // TODO: Wait for the person at the front of the line to make it to the window before letting the player interact
        OnCustomerServed();
    }

    void Start()
    {
        backOfTheLine = transform.GetChild(0).GetComponent<BackOfTheLine>();
        backOfTheLine.GetComponent<BackOfTheLine>().BackOfTheLineReached += OnBackOfTheLineReached;
    }


    void OnCustomerServed()
    {
        NPC lastCustomer = NPCsInLine.Dequeue();
        Debug.Assert(lastCustomer != null);


        int[] NPCOrder = lastCustomer.GetNPCOrder();
        int[] playerOrder = playerOrderPosition.GetPlayerOrder();

        if (OrderMatches(playerOrder, NPCOrder))
        {
            lastCustomer.Leave();
            playerOrderPosition.resetPlayerOrder();
            orderView.DisplayOrder();

            if (NPCOrder[2] > 0)
            {
                gameTimer.AddTime(3f);
                Debug.Log("Add 3 Seconds");
            }
            else if(NPCOrder[1] > 0)
            {
                gameTimer.AddTime(2f);
                Debug.Log("Add 2 Seconds");
            }
            else
            {
                gameTimer.AddTime(1);
                Debug.Log("Add 1 Second");
            }
        }
        else
        {
            Debug.Log("Incorrect Order");
        }
        

        foreach (NPC npc in NPCsInLine)
        {
            npc.SetDestination(npc.transform.position + new Vector3(0,0,-2));
        }
        MoveBackOfTheLineForward();
    }

    public int[] GetFirstOrder()
    {
        NPC firstCustomer = NPCsInLine.Dequeue();
        Debug.Assert(firstCustomer != null);

        int[] NPCOrder = firstCustomer.GetNPCOrder();
        currentCustomerOrder = NPCOrder;
        return currentCustomerOrder;
    }


    void OnBackOfTheLineReached(object sender, EventArgs e)
    {
        NPC npc = ((GameObject)sender).GetComponent<NPC>();
        // Makes sure this is only called the first time the NPC collides with the back of the line
        if (npc.isNavigatingToLine)
        {
            NPCsInLine.Enqueue(npc);
            npc.isNavigatingToLine = false;
            orderView.BuildQueue(npc.GetNPCOrder());
            if (!orderView.orderIsDisplayed)
            {
                orderView.DisplayOrder();
            }
            // Make room
            MoveBackOfTheLineBack();
        }
    }

    void MoveBackOfTheLineBack()
    {
        backOfTheLine.transform.position += new Vector3(0, 0, 2);
        BackOfTheLineMoved?.Invoke(this, null);
    }

    void MoveBackOfTheLineForward()
    {
        backOfTheLine.transform.position += new Vector3(0, 0, -2);
        BackOfTheLineMoved?.Invoke(this, null);
    }

    public bool OrderMatches(int[] playerArray, int[] enemyArray)
    {
        if (playerArray.Length != enemyArray.Length)
        {
            return false;
        }

        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i] != enemyArray[i])
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
