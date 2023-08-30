using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    // Start is called before the first frame update

    public float targetTime = 60.0f;

    public void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            Debug.Log("You died!");
            timerEnded();
        }

    }


    public void AddTime(float time)
    {
        targetTime += time;
    }

    void timerEnded()
    {
        //Write Game Over stuff here
    }


}
