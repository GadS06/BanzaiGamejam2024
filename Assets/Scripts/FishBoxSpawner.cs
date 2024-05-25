using System.Collections.Generic;
using UnityEngine;

public class FishBoxSpawner : MonoBehaviour
{
    public float horSpeed;
    public BoxCollider spawnArea;

    public void SpawnFish(GameObject prefab)
    {
        Vector3 spawnPoint = GetRandomPointInBoxCollider(spawnArea);
        var newOne = Instantiate(prefab, spawnPoint, Quaternion.identity);
        var velocity = horSpeed * new Vector3(Random.Range(0.8f, 1.2f), Random.Range(-0.2f, 0.2f), 0);
        FindAndPushChildRigidbodies(newOne.transform, velocity);
    }

    void FindAndPushChildRigidbodies(Transform parent, Vector3 velocity)
    {
        Rigidbody rb = parent.GetComponent<Rigidbody>();
        if (rb != null)
            rb.velocity = velocity;

        foreach (Transform child in parent)
        {
            FindAndPushChildRigidbodies(child, velocity);
        }
    }

    private Vector3 GetRandomPointInBoxCollider(BoxCollider collider)
    {
        Vector3 center = collider.bounds.center;
        Vector3 size = collider.bounds.size;

        float x = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
        float y = Random.Range(center.y - size.y / 2f, center.y + size.y / 2f);
        float z = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);

        return new Vector3(x, y, z);
    }
}
