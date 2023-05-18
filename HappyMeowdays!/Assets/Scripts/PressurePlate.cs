using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject objectToSpawn;
    public bool spawnOnActivate;
    public bool deleteOnActivate;
    public GameObject spawnLocation;

    private bool isActivated = false;

    public AudioClip buttonPush;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;

            if (spawnOnActivate)
            {
                Instantiate(objectToSpawn, spawnLocation.transform.position, Quaternion.identity);
            }

            if (deleteOnActivate)
            {
                Destroy(gameObject);
            }
        }

        AudioSource.PlayClipAtPoint(buttonPush, transform.position);
    }
}
