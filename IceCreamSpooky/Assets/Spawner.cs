using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public NPC NPCPrefab;
    [SerializeField]
    List<Transform> spawnPoints;

    [SerializeField]
    BackOfTheLine backOfTheLine;

    [SerializeField]
    PointOfSale pointOfSale;

    [SerializeField]
    Transform walkOffDestination;

    private int spawnCount = 0;

    private bool spawnContinuously = false;
    private float spawnInterval = 4.0f;
    private float timeOfLastSpawn;

    void SpawnNPC()
    {
        NPC npc = Instantiate(NPCPrefab, spawnPoints[spawnCount % spawnPoints.Count].position, Quaternion.identity);
        npc.backOfTheLine = backOfTheLine.transform;
        npc.walkOffDestination = walkOffDestination;
        pointOfSale.BackOfTheLineMoved += npc.OnBackOfLineMoved;
        npc.NavigateToBackOfLine();

        timeOfLastSpawn = Time.time;
        spawnCount++;
    }

    public void SetSpawnInterval(float interval)
    {
        spawnInterval = interval;

        // Start spawning continuously if we haven't already
        if (!spawnContinuously)
        {
            spawnContinuously = true;
            SpawnNPC();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnContinuously)
        {
            if (Time.time > timeOfLastSpawn + spawnInterval) 
            {
                SpawnNPC();
            }
        }
    }
}
