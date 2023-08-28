using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfSale : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    BackOfTheLine backOfTheLine;
    // Notify nav agents that the back of the line has moved
    public event EventHandler BackOfTheLineMoved;

    public IceCreamCounter playerOrderPosition;

    Queue<NPC> NPCsInLine = new Queue<NPC>();

    public void Interact()
    {
        if (NPCsInLine.Count == 0)
        {
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

    void OnBackOfTheLineReached(object sender, EventArgs e)
    {
        NPC npc = ((GameObject)sender).GetComponent<NPC>();
        if (npc.isNavigatingToLine)
        {
            NPCsInLine.Enqueue(npc);
            npc.isNavigatingToLine = false;
        }

        MoveBackOfTheLineBack();
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
