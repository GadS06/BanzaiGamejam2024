using System.Collections.Generic;
using UnityEngine;

public class FishBoxSpawner : MonoBehaviour
{
    public BoxCollider spawnArea;
    public bool reverse;

    public void SpawnFish(GameObject prefab, float horSpeed, GameObject skin)
    {
        Vector3 spawnPoint = GetRandomPointInBoxCollider(spawnArea);
        var newOne = Instantiate(prefab, spawnPoint, Quaternion.identity);
        newOne.transform.position = new Vector3(newOne.transform.position.x, newOne.transform.position.y, 0);
        var velocity = horSpeed * new Vector3(Random.Range(0.8f, 1.2f), Random.Range(-0.2f, 0.2f), 0);
        FindAndPushChildRigidbodiesAndAddSkins(newOne.transform, velocity, skin);
    }

    void FindAndPushChildRigidbodiesAndAddSkins(Transform parent, Vector3 velocity, GameObject skin)
    {
        Rigidbody rb = parent.GetComponent<Rigidbody>();
        if (rb != null)
            rb.velocity = velocity;

        var frt = parent.GetComponent<FishReplacementTag>();
        if (frt != null)
        {
            var newSkin = Instantiate(skin, parent);
            if (reverse)
                newSkin.transform.Rotate(0, 180, 0);
        }

        foreach (Transform child in parent)
        {
            FindAndPushChildRigidbodiesAndAddSkins(child, velocity, skin);
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
