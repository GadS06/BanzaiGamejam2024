using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPanelUI : MonoBehaviour
{
    public WeaponUI ElementPrefab;

    public void SetWeapons(List<WeaponBase> weapons, int selectedIdx)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        for (int i = 0; i < weapons.Count; i++)
        {
            var newOne = Instantiate(ElementPrefab, transform);
            newOne.SetWeapon(weapons[i], i == selectedIdx);
        }
    }
}
