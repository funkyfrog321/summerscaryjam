using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeIce : MonoBehaviour
{

    public GameObject npc;
    public GameObject player;

    public bool OrderMatches(int[] playerArray, int[] enemyArray)
    {
        if(playerArray.Length != enemyArray.Length)
        {
            return false;
        }

        for(int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i] != enemyArray[i])
            {
                return false;
            }
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
