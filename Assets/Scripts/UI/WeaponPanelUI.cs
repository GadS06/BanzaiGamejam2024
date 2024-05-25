using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPanelUI : MonoBehaviour
{
    public WeaponUI ElementPrefab;

    public void SetWeapons(List<WeaponBase> weapons)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        foreach(var w in weapons)
        {
            var newOne = Instantiate(ElementPrefab, transform);
            newOne.SetWeapon(w);
        }
    }
}
