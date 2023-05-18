using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounceBack : MonoBehaviour
{
    public float flickForce = 5f;   // The force to apply when flicking
    private Rigidbody rb;           // The rigidbody component of the object being flicked

    private bool isFlicking = false; // Flag to check if the object is currently being flicked

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFlicking)
        {
            // Calculate the flick direction based on the player's movement direction
            Vector3 flickDirection = collision.contacts[0].point - transform.position;
            flickDirection.Normalize();

            // Apply the flick force to the object
            rb.AddForce(flickDirection * flickForce, ForceMode.Impulse);

            isFlicking = true;

            // Reset the isFlicking flag after a short delay
            Invoke(nameof(ResetFlicking), 0.1f);
        }
    }

    private void ResetFlicking()
    {
        isFlicking = false;
    }
}
