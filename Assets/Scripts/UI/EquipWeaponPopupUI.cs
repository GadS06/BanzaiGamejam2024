using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeaponPopupUI : MonoBehaviour
{
    public void StartEquip()
    {
        gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }

    public void SelectSlot(int number)
    {
        FindObjectOfType<ShopUI>().EqipInto(number);
        ClosePopup();
    }
}
