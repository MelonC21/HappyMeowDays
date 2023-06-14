using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Collectable"))
        {
            collision.rigidbody.velocity = transform.TransformDirection(Vector3.up * bounceForce);
        }
    }
}
