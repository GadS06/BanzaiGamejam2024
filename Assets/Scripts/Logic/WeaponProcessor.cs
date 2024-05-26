using System.Collections.Generic;
using UnityEngine;

public class WeaponProcessor : MonoBehaviour
{
    public List<WeaponBase> AllWeaponsInTheGame;

    public List<WeaponBase> EquippedWeapons;

    public LayerMask planeLayer;

    public Cat Cat;

    public WeaponPanelUI ui;

    private Camera mainCamera;

    private int selectedWeapon;

    private void Start()
    {
        mainCamera = Camera.main;

        ui.SetWeapons(EquippedWeapons, selectedWeapon);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Hotkey 1"))
            Select(0);
        if (Input.GetButtonDown("Hotkey 2"))
            Select(1);
        if (Input.GetButtonDown("Hotkey 3"))
            Select(2);
        if (Input.GetButtonDown("Hotkey 4"))
            Select(3);
        if (Input.GetButtonDown("Hotkey 5"))
            Select(4);
        if (Input.GetButtonDown("Hotkey 6"))
            Select(5);

        if (!Cat.buoyancy.floating)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayer))
                {
                    EquippedWeapons[selectedWeapon].Fire(Cat, hit.point);
                    Cat.animator.SetTrigger("Attack");
                }
            }

            if (Input.GetMouseButton(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayer))
                {
                    EquippedWeapons[selectedWeapon].ContinuousFire(Cat, hit.point);
                    Cat.animator.SetTrigger("Attack");
                }
            }
        }
    }

    private void Select(int n)
    {
        selectedWeapon = n;
        if (selectedWeapon >= EquippedWeapons.Count)
            selectedWeapon = EquippedWeapons.Count - 1;
        ui.SetWeapons(EquippedWeapons, selectedWeapon);
    }

    public void EquipWeapon(WeaponBase weapon, int weaponSlot)
    {
        if (EquippedWeapons.Count <= weaponSlot)
        {
            EquippedWeapons.Add(null);
            weaponSlot = EquippedWeapons.Count - 1;
        }

        EquippedWeapons[weaponSlot] = weapon;
        ui.SetWeapons(EquippedWeapons, selectedWeapon);
    }

    public void BuyWeapon(WeaponBase weapon)
    {
        var score = FindObjectOfType<Score>();
        bool success = score.TrySpend(weapon.Price);
        if (success)
        {
            weapon.IsBought = true;
            FindObjectOfType<ShopUI>(true).Reload(AllWeaponsInTheGame);
        }
    }

    public void OpenShop()
    {
        var shop = FindObjectOfType<ShopUI>(true);
        shop.gameObject.SetActive(true);
        shop.Reload(AllWeaponsInTheGame);
    }
}
