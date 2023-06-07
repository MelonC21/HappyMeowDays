using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public GameObject objectToCountPrefab;
    public int maxObjects;
    public GameObject objectToSpawnPrefab;
    public GameObject spawnPoint;

    private int currentCount = 0;

    void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag(objectToCountPrefab.tag))
        {
            Debug.Log("in");
            currentCount++;

            if (currentCount >= maxObjects)
            {
                SpawnObject();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag(objectToCountPrefab.tag))
        {
            Debug.Log("out");
            currentCount--;
        }
    }

    void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        currentCount = 0;
    }
}
