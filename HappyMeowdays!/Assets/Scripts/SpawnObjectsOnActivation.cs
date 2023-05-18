using System; 
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsOnActivation : MonoBehaviour
{
    public List<GameObject> objectsToCheck; // The list of objects to check for activation
    public GameObject objectToSpawn; // The object to spawn when all objects are activated
    public Transform spawnPosition; // The position where the object should be spawned

    private int activatedObjectCount; // Number of activated objects

    public event Action OnAllObjectsActivated; // Event triggered when all objects are activated

    private void Start()
    {
        // Initialize the count of activated objects
        activatedObjectCount = 0;
    }

    private void Update()
    {
        // Subscribe to the event of each object
        foreach (GameObject obj in objectsToCheck)
        {
            TriggerActivation triggerActivation = obj.AddComponent<TriggerActivation>();
            triggerActivation.OnObjectActivated += HandleObjectActivated;
        }
    }

    private void HandleObjectActivated()
    {
        activatedObjectCount++;

        // Check if all objects are activated
        if (activatedObjectCount >= objectsToCheck.Count)
        {
            OnAllObjectsActivated?.Invoke();
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPosition.position, spawnPosition.rotation);
        // Add any additional logic or modifications to the spawned object as needed
    }
}

public class TriggerActivation : MonoBehaviour
{
    public event Action OnObjectActivated; // Event triggered when the object is activated

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Change the tag to match your objects
        {
            gameObject.SetActive(true);
            OnObjectActivated?.Invoke();
        }
    }
}