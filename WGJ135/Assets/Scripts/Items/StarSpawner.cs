using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class StarSpawner : MonoBehaviour
    {
        [Header("Prefabs")]
        public List<GameObject> starPrefabs = new List<GameObject>();

        [Header("Settings")] public float timeUntilFirstSpawn = 2f;
        public float timeBetweenspawns = 5f;
    
        private List<Transform> spawns = new List<Transform>();
    
        private void Start()
        {
            GetSpawnPositions();
            InvokeRepeating("Spawn", timeUntilFirstSpawn, timeBetweenspawns);

            GameEvents.BlueCannon += RemoveBlue;
            GameEvents.RedCannon += RemoveRed;
            GameEvents.YellowCannon += RemoveYellow;
            GameEvents.PurpleCannon += RemovePurple;
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
            if (starPrefabs.Count <= 0) return;
            
            int randomObj = UnityEngine.Random.Range(0, starPrefabs.Count);
            int randomSpawn = UnityEngine.Random.Range(0, spawns.Count);

            if (spawns[randomSpawn].childCount != 0) return;
            
            GameObject obj = Instantiate(starPrefabs[randomObj], spawns[randomSpawn]);
            obj.transform.SetParent(spawns[randomSpawn]);
        }

        private void RemoveRed()
        {
            if (starPrefabs.Count <= 0) return;
            for (var index = 0; index < starPrefabs.Count; index++)
            {
                var starPrefab = starPrefabs[index];
                if (starPrefab.GetComponent<Star>().starColor == Star.STAR.Red)
                {
                    starPrefabs.RemoveAt(index);
                }
            }
        }
        
        private void RemoveBlue()
        {
            if (starPrefabs.Count <= 0) return;
            for (var index = 0; index < starPrefabs.Count; index++)
            {
                var starPrefab = starPrefabs[index];
                if (starPrefab.GetComponent<Star>().starColor == Star.STAR.Blue)
                {
                    starPrefabs.RemoveAt(index);
                }
            }
        }
        
        private void RemoveYellow()
        {
            if (starPrefabs.Count <= 0) return;
            for (var index = 0; index < starPrefabs.Count; index++)
            {
                var starPrefab = starPrefabs[index];
                if (starPrefab.GetComponent<Star>().starColor == Star.STAR.Yellow)
                {
                    starPrefabs.RemoveAt(index);
                }
            }
        }
        
        private void RemovePurple()
        {
            if (starPrefabs.Count <= 0) return;

            for (var index = 0; index < starPrefabs.Count; index++)
            {
                var starPrefab = starPrefabs[index];
                if (starPrefab.GetComponent<Star>().starColor == Star.STAR.Purple)
                {
                    starPrefabs.RemoveAt(index);
                }
            }
        }

        private void OnDestroy()
        {
            GameEvents.BlueCannon -= RemoveBlue;
            GameEvents.RedCannon -= RemoveRed;
            GameEvents.YellowCannon -= RemoveYellow;
            GameEvents.PurpleCannon -= RemovePurple;
        }
    }
}