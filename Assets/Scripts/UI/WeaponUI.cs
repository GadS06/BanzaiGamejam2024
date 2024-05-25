using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public TMP_Text Label;
    public Image Background;
    public Image Image;

    public void SetWeapon(WeaponBase weapon)
    {
        Image.sprite = weapon.Icon;
        Label.text = "";
    }
}
