using System.Collections.Generic;
using UnityEngine;

public class ClickProcessor : MonoBehaviour
{
    public List<WeaponBase> Weapons;

    public LayerMask planeLayer;

    public Cat Cat;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
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
