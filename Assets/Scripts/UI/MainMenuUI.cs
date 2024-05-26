using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().StartLevel(0);
    }
}
