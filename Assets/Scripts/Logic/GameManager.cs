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
            orch.StartLevel(level);

            WaterUp.material = level.WaterMaterialUp;
            WaterSide.material = level.WaterMaterialSide;
            RenderSettings.skybox = level.Skybox;

            FindObjectOfType<BossHpUI>(true).gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        FindObjectOfType<LevelOrchestrator>().StopLevel();
        DespawnBosses();
    }

    public void DespawnBosses()
    {
        foreach (var hp in FindObjectsOfType<Health>(true))
        {
            if (hp.showAsBossHp)
            {
                Destroy(hp.gameObject);
            }
        }
    }
}
