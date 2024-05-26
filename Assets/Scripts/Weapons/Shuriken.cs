using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : WeaponBase
{
    public int NumberOfProj = 10;
    public Rigidbody Projectile;
    public float Speed = 7;
    public float Spread = 10;
    public float RotationSpeed;

    public override void Fire(Cat cat, Vector3 mousePos)
    {
        for (int i = 0; i < NumberOfProj; i++)
        {
            var newOne = Throw(Projectile, Speed, cat, mousePos + new Vector3(Random.Range(- Spread / 2f, Spread / 2f), 0, 0));
            newOne.angularVelocity = Vector3.forward * RotationSpeed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
