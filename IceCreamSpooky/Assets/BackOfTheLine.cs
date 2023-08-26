using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackOfTheLine : MonoBehaviour
{
    public event EventHandler BackOfTheLineReached;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Somethign collided");
        if (other.CompareTag("NPC"))
        {
            Debug.Log("NPC reached the back of the line");

            BackOfTheLineReached?.Invoke(other.gameObject, new EventArgs());
        }
    }
}
