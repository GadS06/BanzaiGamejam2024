using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFish : MonoBehaviour
{
    public LayerMask layerMask;
    public int damage = 1;

    Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int collidedLayer = other.gameObject.layer;

        Process(other.gameObject, collidedLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int collidedLayer = collision.gameObject.layer;

        Process(collision.gameObject, collidedLayer);
    }

    void Process(GameObject other, int collidedLayer)
    {
        if (((1 << collidedLayer) & layerMask) != 0)
        {
            var hp = other.GetComponent<Health>();

            if (!hp)
            {
                Destroy(other);
                score.AddScore(1);
            }
            else
            {
                hp.TakeDamage(damage);
            }
        }
    }
}
