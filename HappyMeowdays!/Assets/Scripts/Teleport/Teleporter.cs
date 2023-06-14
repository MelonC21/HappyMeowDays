using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject TeleporterGate;
    public float offsetDistance;
    private Quaternion exitRotation;


    [SerializeField] private AudioClip teleportedThrough;

    public void TeleportPlayer(GameObject player)
    {
        Vector3 offset = TeleporterGate.transform.forward * offsetDistance;
        Vector3 finalPosition = TeleporterGate.transform.position + offset;
        player.transform.position = finalPosition;
        exitRotation = Quaternion.LookRotation(TeleporterGate.transform.forward, Vector3.up);
        AudioSource.PlayClipAtPoint(teleportedThrough, finalPosition);
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            TeleportPlayer(other.gameObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.transform.rotation = exitRotation;
        }
    }
}
