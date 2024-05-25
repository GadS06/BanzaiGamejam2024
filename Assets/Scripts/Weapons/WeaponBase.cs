using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public abstract void Fire(Cat cat, Vector3 mousePos);

    protected Rigidbody Throw(Rigidbody prefab, float speed, Cat cat, Vector3 mousePos)
    {
        var dir = (mousePos - cat.rb.position).normalized;
        var newOne = Instantiate(prefab, cat.transform.position, Quaternion.LookRotation(dir, Vector3.back));
        newOne.velocity = dir * speed;
        return newOne;
    }
}
