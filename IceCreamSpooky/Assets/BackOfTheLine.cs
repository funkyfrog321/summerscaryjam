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
        if (other.CompareTag("NPC"))
        {
            BackOfTheLineReached?.Invoke(other.gameObject, new EventArgs());
        }
    }
}
