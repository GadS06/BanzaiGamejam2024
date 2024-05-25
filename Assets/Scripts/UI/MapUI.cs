using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    public void StartLevel(int number)
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().StartLevel(number);
    }
}
