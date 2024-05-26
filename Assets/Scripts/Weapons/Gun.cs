using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    public Rigidbody bullet;
    public float speed;
    public float BulletPerSecond;
    public float LastShotTime;
    public float Knockback;


    private void Start()
    {
        LastShotTime = 0;
    }

    public override void Fire(Cat cat, Vector3 mousePos)
    {
        Shot(bullet, speed, cat, mousePos);
    }

    public override void ContinuousFire(Cat cat, Vector3 mousePos)
    {
        Shot(bullet, speed, cat, mousePos);
    }

    void Shot(Rigidbody prefab, float speed, Cat cat, Vector3 mousePos)
    {
        if (Time.time - LastShotTime > 1 / BulletPerSecond)
        {
            LastShotTime = Time.time;
            Throw(bullet, speed, cat, mousePos);

            var dir = (mousePos - cat.rb.position).normalized;
            if (!cat.isGrounded)
                cat.rb.velocity -= dir * Knockback;
        }
    }
}
