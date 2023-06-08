using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlateTriggerScene : MonoBehaviour
{
    public string sceneName; // name of the scene to load
    public KeyCode activationKey = KeyCode.Space; // optional key to activate the trigger

    private bool isActive = false; // whether the trigger is currently active

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = false;
        }
    }

    private void Update()
    {
        // check if the trigger is active and the activation key is pressed (if specified)
        if (isActive && (activationKey == KeyCode.None || Input.GetKeyDown(activationKey)))
        {
            // load the next scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
