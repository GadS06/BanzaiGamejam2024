using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : WeaponBase
{
    public Rigidbody HookPrefab;
    public float Speed;
    public float MaxThrowTime;
    private Rigidbody HookInstance;
    private bool isRetracting;
    private float throwTime;
    private Cat Cat;

    public override void Fire(Cat cat, Vector3 mousePos)
    {
        if (HookInstance == null)
        {
            Cat = cat;
            HookInstance = Throw(HookPrefab, Speed, cat, mousePos);
            isRetracting = false;
            throwTime = Time.time;
        }
    }

    private void Update()
    {
        if ((Input.GetMouseButtonUp(0)
            || (Time.time - throwTime) > MaxThrowTime)
            && HookInstance != null
            && !isRetracting)
        {
            isRetracting = true;
            HookInstance.velocity = (Cat.rb.position - HookInstance.position).normalized * Speed;
        }

        if (isRetracting
            && HookInstance != null && Cat != null
            && Vector3.Distance(HookInstance.position, Cat.rb.position) < 1)
        {
            isRetracting = false;
            Destroy(HookInstance.gameObject);
        }

        if (HookInstance != null
            && Time.time - throwTime > 2.1f * MaxThrowTime)
        {
            isRetracting = false;
            Destroy(HookInstance.gameObject);
        }
    }
}
