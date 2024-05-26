using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public void OpenMap()
    {
        FindObjectOfType<MapUI>(true).gameObject.SetActive(true);
    }
}
