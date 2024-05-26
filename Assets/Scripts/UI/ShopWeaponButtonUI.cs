using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponButtonUI : MonoBehaviour
{
    public WeaponBase Weapon;

    public Image Img;
    public TMP_Text Lbl;

    public void Init(WeaponBase weapon)
    {
        Weapon = weapon;
        Img.sprite = Weapon.Icon;
        Lbl.text = Weapon.IsBought ? "" : $"{Weapon.Price} рыбов";
    }

    public void OnPress()
    {
        if (Weapon.IsBought)
            FindObjectOfType<ShopUI>().StartEquip(Weapon);
        else
            FindObjectOfType<WeaponProcessor>().BuyWeapon(Weapon);
    }
}
