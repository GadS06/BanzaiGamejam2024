using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : WeaponBase
{
    public Rigidbody DynamitePrefab;
    public float Speed;
    public float RotationSpeed;

    private Rigidbody DynamiteInstance;

    public override void Fire(Cat cat, Vector3 mousePos)
    {
        DynamiteInstance = Throw(DynamitePrefab, Speed, cat, mousePos);
        DynamiteInstance.angularVelocity = Vector3.forward * RotationSpeed;

        // TODO: это для гранат
        /*
        if (DynamiteInstance == null)
        {
            DynamiteInstance = Throw(DynamitePrefab, Speed, cat, mousePos);
            DynamiteInstance.angularVelocity = Vector3.forward * RotationSpeed;
        }
        else
        {
            Destroy(DynamiteInstance.gameObject);
        }
        */
    }
}
