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

    void SpawnNPC()
    {
        NPC npc = Instantiate(NPCPrefab, spawnPoints[spawnCount % spawnPoints.Count].position, Quaternion.identity);
        npc.backOfTheLine = backOfTheLine.transform;
        npc.walkOffDestination = walkOffDestination;
        pointOfSale.BackOfTheLineMoved += npc.OnBackOfLineMoved;
        npc.NavigateToBackOfLine();

        spawnCount++;
    }

    void Start()
    {
        SpawnNPC();
        SpawnNPC();
        SpawnNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
