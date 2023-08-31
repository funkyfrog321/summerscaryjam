using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float targetTime = 60.0f;

    // Define when each stage should start. Stages affect game difficulty
    // This is not the time between each stage, rather the Time.time at which each stage starts
    public float[] stageTimes = { 10f, 20f, 40f, 80f };
    private int stageCounter = 0;
    public float[] stageSpawnIntervals = { 4f, 3f, 2f, 1f };

    private float timeOfLastCreepyStuff = 0f;
    private bool creepyStuff = false;
    private bool gameOver = false;
    public Animator truckRocker;

    public GameOverMenu gameOverMenu;
    public Spawner spawner;
    public float alltime;
    public GameObject myTime;

    public void Update()
    {
        if (gameOver) return;

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            Debug.Log("You died!");
            timerEnded();
        }
        
        // Do creepy stuff to indicate the player is running out of time
        if (targetTime <= 10.0f)
        {
            if (!creepyStuff)
            {
                // The player has less than 10 seconds left 
                creepyStuff = true;
                AudioManager.instance.PlaySound(1);
                truckRocker.SetTrigger("Rock");
                timeOfLastCreepyStuff = Time.time; // Might use this so the rock animation doesn't happen too frequently
            }
        }
        else
        {
            creepyStuff = false;
        }
        
        if (stageCounter < stageTimes.Length)
        {
            // Every stage decreases the time between NPC spawns
            if (Time.time > stageTimes[stageCounter])
            {
                stageCounter++;
                spawner.SetSpawnInterval(stageSpawnIntervals[stageCounter]);

            }
        }

        TotalTime();

    }


    public void TotalTime()
    {
        alltime += Time.deltaTime;
    }

    public void AddTime(float time)
    {
        targetTime += time;
    }

    void timerEnded()
    {
        gameOver = true;
        AudioManager.instance.PlaySound(3);
        gameOverMenu.ShowGameOverMenu();
        myTime.GetComponent<TextMeshProUGUI>().SetText(Time.timeSinceLevelLoad.ToString("f2") + " seconds");
        // Save this for when we have an animation to play
        //StartCoroutine(DelayedGameOverMenu());
    }

    IEnumerator DelayedGameOverMenu()
    {
        yield return new WaitForSeconds(3f);
        gameOverMenu.ShowGameOverMenu();

    }

}
