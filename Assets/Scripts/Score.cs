using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log(score);
    }
}
