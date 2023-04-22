using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject TeleporterGate;
    public float offsetDistance;

    public void TeleportPlayer(GameObject player)
    {
        Vector3 offset = TeleporterGate.transform.forward * offsetDistance;
        Vector3 finalPosition = TeleporterGate.transform.position + offset;
        player.transform.position = finalPosition;
        player.transform.forward = TeleporterGate.transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            TeleportPlayer(other.gameObject);
        }
    }
}
