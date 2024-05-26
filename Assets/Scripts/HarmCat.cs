using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HarmCat : MonoBehaviour
{
    public LayerMask layerMask;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        int collidedLayer = other.gameObject.layer;

        Process(other.gameObject, collidedLayer);
    }

    void Process(GameObject other, int collidedLayer)
    {
        if (((1 << collidedLayer) & layerMask) != 0)
        {
            var cat = other.GetComponent<Cat>();

            cat.AddHp(-damage);
        }
    }
}
