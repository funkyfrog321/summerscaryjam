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
        MoveBackOfTheLineBack();
    }

    void MoveBackOfTheLineBack()
    {
        backOfTheLine.transform.position += new Vector3(0, 0, 1);
    }

    void MoveBackOfTheLineForward()
    {
        backOfTheLine.transform.position += new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
