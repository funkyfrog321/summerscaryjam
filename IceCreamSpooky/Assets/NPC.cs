using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform backOfTheLine;
    public Transform walkOffDestination;

    public bool isNavigatingToLine;

    public int[] NPCiceCreamOrder = { 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        NPCOrder();
    }

    public void Leave()
    {
        agent.SetDestination(walkOffDestination.position);
    }

    public void SetDestination(Vector3 target)
    {
        if (agent != null)
        {
            agent.SetDestination(target);
        }
    }

    public void OnBackOfLineMoved(object sender, EventArgs e)
    {
        if (isNavigatingToLine)
        {
            agent.SetDestination(backOfTheLine.position);
        }
    }

    public void NavigateToBackOfLine()
    {
        isNavigatingToLine = true;
        agent.SetDestination(backOfTheLine.position);
    }

    public void NPCOrder()
    {
        int flavor1 = UnityEngine.Random.Range(1, 4);
        NPCiceCreamOrder[0] = flavor1;

        int flavor2 = UnityEngine.Random.Range(0, 4);
        NPCiceCreamOrder[1] = flavor2;

        int flavor3 = UnityEngine.Random.Range(0, 4);

        if (flavor2 == 0)
        {
            NPCiceCreamOrder[2] = 0;
        }
        else
        {
            NPCiceCreamOrder[2] = flavor3;
        }
    }

    public int[] GetNPCOrder()
    {
        return NPCiceCreamOrder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
