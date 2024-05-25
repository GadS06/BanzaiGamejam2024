using UnityEngine;

public class SelfDestructOnCollisionWithLayer : MonoBehaviour
{
    public LayerMask targetLayer;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided GameObject is on the target layer
        if (targetLayer == (targetLayer | (1 << collision.gameObject.layer)))
        {
            // Destroy this GameObject upon collision with the target layer
            Destroy(gameObject);
        }
    }
}