using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationPost : MonoBehaviour
{
    [SerializeField] private AudioClip popupSound;
    [SerializeField] private Canvas infoPost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("in");
            infoPost.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(popupSound, transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("out");
            infoPost.gameObject.SetActive(false);
        }
    }
}
