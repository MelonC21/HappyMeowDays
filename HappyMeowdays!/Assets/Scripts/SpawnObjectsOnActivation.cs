using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsOnActivation : MonoBehaviour
{
    public List<GameObject> objectsToCheck; // The list of objects to check for activation
    public GameObject objectToSpawn; // The object to spawn when all objects are activated
    public Transform spawnPosition; // The position where the object should be spawned

    private bool allObjectsActivated; // Flag indicating if all objects are activated

    private void Update()
    {
        // Reset the flag before checking
        allObjectsActivated = true;

        // Check if all objects in the list are activated
        foreach (GameObject obj in objectsToCheck)
        {
            if (!obj.activeSelf)
            {
                allObjectsActivated = false;
                break;
            }
        }

        // If all objects are activated, spawn the desired object
        if (allObjectsActivated)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPosition.position, spawnPosition.rotation);
        // Add any additional logic or modifications to the spawned object as needed
    }
}