using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerManager : MonoBehaviour
{

    public GameObject[] stageBosses; 
    public Transform[] spawnPoints;
    public int numberOfBosses = 2;


    public void SpawnStageBoss(int bossIndex)
    {
        if (stageBosses.Length == 0)
        {
            Debug.LogWarning("No stage boss prefabs assigned.");
            return;
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned for stage boss spawning.");
            return;
        }


        foreach (Transform spawnPoint in spawnPoints)
        {
            // Spawn the boss prefabs at the current spawn point
            foreach (GameObject bossPrefab in stageBosses)
            {
                Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
