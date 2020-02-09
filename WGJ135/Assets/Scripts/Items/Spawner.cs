using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public List<GameObject> prefabs = new List<GameObject>();

    [Header("Settings")] public float timeUntilFirstSpawn = 2f;
    public float timeBetweenspawns = 5f;
    
    private List<Transform> spawns = new List<Transform>();
    
    private void Start()
    {
        GetSpawnPositions();
        InvokeRepeating("Spawn", timeUntilFirstSpawn, timeBetweenspawns);
    }

    private void GetSpawnPositions()
    {
        foreach (Transform child in transform)
        {
            spawns.Add(child);
        }
    }

    private void Spawn()
    {
        int randomObj = UnityEngine.Random.Range(0, prefabs.Count);
        int randomSpawn = UnityEngine.Random.Range(0, spawns.Count);

        if (spawns[randomSpawn].childCount == 0)
        {
            GameObject obj = Instantiate(prefabs[randomObj], spawns[randomSpawn]);
            obj.transform.SetParent(spawns[randomSpawn]);
        }
    }
}
