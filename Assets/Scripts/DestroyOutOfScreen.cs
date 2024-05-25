using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Destroy the object when it becomes invisible
        Destroy(gameObject);
    }
}
