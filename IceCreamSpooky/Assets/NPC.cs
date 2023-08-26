using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform backOfTheLine;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(backOfTheLine.position);
    }

    void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
