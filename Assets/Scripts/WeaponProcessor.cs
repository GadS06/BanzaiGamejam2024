using System.Collections.Generic;
using UnityEngine;

public class WeaponProcessor : MonoBehaviour
{
    public List<WeaponBase> Weapons;

    public LayerMask planeLayer;

    public Cat Cat;

    public WeaponPanelUI ui;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        ui.SetWeapons(Weapons);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayer))
            {
                Vector3 spawnPosition = hit.point;
                //Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                Weapons[0].Fire(Cat, hit.point);
            }
        }
    }
}
