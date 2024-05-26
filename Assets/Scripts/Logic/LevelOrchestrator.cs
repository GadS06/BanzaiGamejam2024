using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrchestrator : MonoBehaviour
{
    public Level CurrentLevel;
    private List<FishSpawn> Spawns;
    private int NextSpawn = 0;
    public List<FishBoxSpawner> FishSpawners;
    public List<GameObject> FishPrefabs;
    public List<GameObject> FishSkins;
    public float FishPerSecond;
    public float LevelStartTime;

    public void Start()
    {
        PrepareSpawns();
        LevelStartTime = Time.time;
    }

    public void Update()
    {
        if (Time.time - LevelStartTime > CurrentLevel.duration)
        {
            LevelFinished();
        }
        else
        {
            while (NextSpawn < Spawns.Count
                && Spawns[NextSpawn].time < Time.time - LevelStartTime)
            {
                Spawn(Spawns[NextSpawn]);
                NextSpawn++;
            }
        }
    }

    void PrepareSpawns()
    {
        Spawns = new List<FishSpawn>();
        foreach (var s in CurrentLevel.Spawns)
        {
            for (int i = 0; i < s.Count; i++)
            {
                Spawns.Add(new FishSpawn
                {
                    time = s.Start + (s.Finish - s.Start) * ((float)i / s.Count),
                    FishSpeed = s.FishSpeed,
                    prefab = s.Prefab,
                    SpawnPoint = s.SpawnPoint,
                });
            }
        }
        Spawns.Sort((FishSpawn a, FishSpawn b) => (int)Mathf.Sign(a.time - b.time));
    }

    void Spawn(FishSpawn spawn)
    {
        var spawner = spawn.SpawnPoint == SpawnPointType.leftWall ? FishSpawners[0] : FishSpawners[1];
        var skin = FishSkins[Random.Range(0, FishSkins.Count)];
        spawner.SpawnFish(spawn.prefab, spawn.FishSpeed, skin);
    }

    void LevelFinished()
    {

    }

    class FishSpawn
    {
        public float time;
        public GameObject prefab;
        public SpawnPointType SpawnPoint;
        public float FishSpeed;
    }
}

