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

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
