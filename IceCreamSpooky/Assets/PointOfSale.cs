using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfSale : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject backOfTheLine;

    void Start()
    {
        backOfTheLine = transform.GetChild(0).gameObject;
        backOfTheLine.GetComponent<BackOfTheLine>().BackOfTheLineReached += OnBackOfTheLineReached;
    }

    void OnBackOfTheLineReached(object sender, EventArgs e)
    {
        GameObject gameObject = (GameObject)sender;

        Debug.Log("Received event");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
