using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private WeaponBase nowEquipping;

    public ShopWeaponButtonUI ButtonPrefab;
    public GameObject PlaceForButtons;

    public void Reload(List<WeaponBase> weapons)
    {
        foreach (Transform child in PlaceForButtons.transform)
            Destroy(child.gameObject);

        for (int i = 0; i < weapons.Count; i++)
        {
            var newOne = Instantiate(ButtonPrefab, PlaceForButtons.transform);
            newOne.Init(weapons[i]);
        }
    }

    public void StartEquip(WeaponBase weapon)
    {
        nowEquipping = weapon;
        FindObjectOfType<EquipWeaponPopupUI>(true).StartEquip();
    }

    public void EqipInto(int slotNum)
    {
        FindObjectOfType<WeaponProcessor>().EquipWeapon(nowEquipping, slotNum);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
