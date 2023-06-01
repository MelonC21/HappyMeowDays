using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnstest : MonoBehaviour
{
    [SerializeField] private Transform[] SpawnPoint;

    [SerializeField] private GameObject[] desiredSpawnables;

    [SerializeField] private float spawnTimeTick;

    //determines if the spawner will be infinite
    [SerializeField] private bool infiniteSwitch;

    private float timerCountdown;

    private void Start()
    {
        SingleSpawnItems();
    }


    private void Update()
    {
        if (infiniteSwitch)
        {
            timerCountdown -= Time.deltaTime;
            if (timerCountdown < 0)
            {
                timerCountdown = spawnTimeTick;
                SpawnItems();

            }
        }
    }
    private void SpawnItems()
    {
        int spawnIndex = Random.Range(0, SpawnPoint.Length);
        int objectIndex = Random.Range(0, desiredSpawnables.Length);
        Instantiate(desiredSpawnables[objectIndex], new Vector3(SpawnPoint[spawnIndex].position.x, SpawnPoint[spawnIndex].position.y, SpawnPoint[spawnIndex].position.z), Quaternion.identity);
    }

    private void SingleSpawnItems()
    {
        int spawnIndex = Random.Range(0, SpawnPoint.Length);
        int objectIndex = Random.Range(0, desiredSpawnables.Length);
        foreach (GameObject spawnable in desiredSpawnables)
        {
            Instantiate(spawnable, new Vector3(SpawnPoint[spawnIndex].position.x, SpawnPoint[spawnIndex].position.y, SpawnPoint[spawnIndex].position.z), Quaternion.identity);
        }
    }

}
