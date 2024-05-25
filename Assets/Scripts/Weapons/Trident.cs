using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trident : WeaponBase
{
    public Rigidbody TridentPrefab;
    public float Speed;
    public float Knockback;

    public override void Fire(Cat cat, Vector3 mousePos)
    {
        Throw(TridentPrefab, Speed, cat, mousePos);

        var dir = (mousePos - cat.rb.position).normalized;
        if (!cat.isGrounded)
            cat.rb.velocity -= dir * Knockback;
    }
}
