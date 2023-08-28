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

        lastCustomer.Leave();

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


    // Update is called once per frame
    void Update()
    {
        
    }
}
