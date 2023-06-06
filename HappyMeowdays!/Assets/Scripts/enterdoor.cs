using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterdoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float Xdis = 0f;
    [SerializeField] public float Ydis = 0f;
    [SerializeField] public float Zdis = 0f;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entered collider belongs to the player character
        if (other.CompareTag("Player"))
        {
            // Get the player's rigidbody component
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            // Check if the player has a valid rigidbody component
            if (playerRigidbody != null)
            {
                // Store the player's current position
                Vector3 playerPosition = other.transform.position;

                // Calculate the new position by adding 4 to the X and Z components
                playerPosition.x += Xdis;
                playerPosition.y += Ydis;
                playerPosition.z += Zdis;

                // Update the player's position
                other.transform.position = playerPosition;
            }
        }
    }
}
