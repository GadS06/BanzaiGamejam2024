using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenLvlUI : MonoBehaviour
{
    public void OpenMap()
    {
        FindObjectOfType<MapUI>(true).gameObject.SetActive(true);
    }

    public void OpenShop()
    {
        FindObjectOfType<WeaponProcessor>(true).OpenShop();
    }
}
