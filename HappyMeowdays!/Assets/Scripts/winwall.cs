using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winwall : MonoBehaviour
{
    public GameObject wall;
    public GameObject objectToActivate;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
        {
            // Check if the entered collider belongs to the player character
            if (other.CompareTag("Player"))
            {
                wall.SetActive(false);
                objectToActivate.SetActive(true);
            }
        }
}
