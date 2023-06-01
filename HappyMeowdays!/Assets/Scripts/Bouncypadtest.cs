using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncypadtest : MonoBehaviour
{
    [SerializeField] private float bounceForce;

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = transform.TransformDirection(Vector3.up * bounceForce);
    }
}
