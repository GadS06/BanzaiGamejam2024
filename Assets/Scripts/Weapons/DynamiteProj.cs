using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteProj : MonoBehaviour
{
    public float fishSeeRadius = 1f;
    public float explosionSize = 3f;
    public LayerMask layerMask;
    public GameObject Explosion;

    void Update()
    {
        // Perform an overlap sphere check around the position of this GameObject
        Collider[] colliders = Physics.OverlapSphere(transform.position, fishSeeRadius, layerMask);

        if (colliders.Length > 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        var newOne = Instantiate(Explosion);
        newOne.transform.localScale = Vector3.one * explosionSize;
        newOne.transform.position = transform.position;
        Destroy(gameObject);
    }
}
