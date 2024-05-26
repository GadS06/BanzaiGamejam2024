using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    ScoreUI ui;

    private void Start()
    {
        ui = FindObjectOfType<ScoreUI>();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ui.SetScore(score);
    }

    public bool TrySpend(int scoreToSpend)
    {
        if (score >= scoreToSpend)
        {
            score -= scoreToSpend;
            ui.SetScore(score);
            return true;
        }
        else
        {
            return false;
        }
    }
}
