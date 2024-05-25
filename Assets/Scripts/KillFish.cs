using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFish : MonoBehaviour
{
    public LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {
        int collidedLayer = other.gameObject.layer;

        if (((1 << collidedLayer) & layerMask) != 0)
        {
            Destroy(other.attachedRigidbody.gameObject);
            FindObjectOfType<Score>().AddScore(1);
        }
    }
}
