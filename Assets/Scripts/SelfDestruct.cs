using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructTime = 3f; // Time in seconds before self-destruct

    void Start()
    {
        // Destroy the GameObject after the specified duration
        Destroy(gameObject, selfDestructTime);
    }
}
