using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float SpeedAdd;
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = transform.TransformDirection(Vector3.forward * SpeedAdd);
    }
}
