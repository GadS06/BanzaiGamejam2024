using System.Collections.Generic;
using UnityEngine;

public class WeaponProcessor : MonoBehaviour
{
    public List<WeaponBase> Weapons;

    public LayerMask planeLayer;

    public Cat Cat;

    public WeaponPanelUI ui;

    private Camera mainCamera;

    private int selectedWeapon;

    private void Start()
    {
        mainCamera = Camera.main;

        ui.SetWeapons(Weapons, selectedWeapon);
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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayer))
            {
                Weapons[selectedWeapon].Fire(Cat, hit.point);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayer))
            {
                Weapons[selectedWeapon].ContinuousFire(Cat, hit.point);
            }
        }
    }

    private void Select(int n)
    {
        selectedWeapon = n;
        if (selectedWeapon >= Weapons.Count)
            selectedWeapon = Weapons.Count - 1;
        ui.SetWeapons(Weapons, selectedWeapon);
    }
}
