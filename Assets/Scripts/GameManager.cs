using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Level> Levels;
    public MeshRenderer WaterUp;
    public MeshRenderer WaterSide;

    public void StartLevel(int number)
    {
        if (Levels.Count > number && number >= 0)
        {
            var level = Levels[number];

            var orch = FindObjectOfType<LevelOrchestrator>();
            orch.CurrentLevel = level;
            orch.LevelStartTime = Time.time;

            WaterUp.material = level.WaterMaterialUp;
            WaterSide.material = level.WaterMaterialSide;
            RenderSettings.skybox = level.Skybox;
        }
    }
}
