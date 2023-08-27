using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackOfTheLine : MonoBehaviour
{
    public event EventHandler BackOfTheLineReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            BackOfTheLineReached?.Invoke(other.gameObject, new EventArgs());
        }
    }
}
