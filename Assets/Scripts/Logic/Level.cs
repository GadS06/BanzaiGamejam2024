using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "SC/Level")]
public class Level : ScriptableObject
{
    public float duration = 60;
    public List<Spawn> Spawns;
    public Material WaterMaterialUp;
    public Material WaterMaterialSide;
    public Material Skybox;
    public GameObject Boss;
}

[Serializable]
public class Spawn
{
    public GameObject Prefab;
    public float Start;
    public float Finish;
    public int Count;
    public SpawnPointType SpawnPoint;
    public float FishSpeed;
}

public enum SpawnPointType
{
    leftWall,
    rightWall,
}