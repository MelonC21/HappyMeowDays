using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public GameObject objectToCountPrefab;
    public int maxObjects;
    public GameObject objectToSpawnPrefab;
    public GameObject spawnPoint;

    [SerializeField] private AudioClip collectedIn;
    [SerializeField] private AudioClip collectedComplete;

    private int currentCount = 0;

    void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag(objectToCountPrefab.tag))
        {
            Debug.Log("in");
            currentCount++;
            AudioSource.PlayClipAtPoint(collectedIn, transform.position);

            if (currentCount >= maxObjects)
            {
                SpawnObject();
                AudioSource.PlayClipAtPoint(collectedComplete, transform.position);
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
