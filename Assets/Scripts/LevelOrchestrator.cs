using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrchestrator : MonoBehaviour
{
    public List<FishBoxSpawner> FishSpawners;
    public List<GameObject> FishPrefabs;
    public float FishPerSecond;

    private float LastFishTime;

    public void Update()
    {
        float delay = 1 / FishPerSecond;
        if (Time.time - LastFishTime > delay)
        {
            var prefab = FishPrefabs[Random.Range(0, FishPrefabs.Count)];
            FishSpawners[Random.Range(0, FishSpawners.Count)].SpawnFish(prefab);
            LastFishTime = Time.time;
        }
    }
}
