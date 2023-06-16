using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectInteractable objectInteractable;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectInteractable == null)
            {
                //not carrying an object, trying to grab
                float interactRange = 2f;
                Collider[] colliderArray = Physics.OverlapSphere(playerCameraTransform.position, interactRange);
                foreach (Collider collider in colliderArray)
                {
                    if (collider.transform.TryGetComponent(out objectInteractable))
                    {
                        objectInteractable.Grab(objectGrabPointTransform);
                        Debug.Log("Picked Up");
                    }
                }
            }
            else
            {
                //currently carrying something, drop
                float interactRange = 2f;
                Collider[] colliderArray = Physics.OverlapSphere(playerCameraTransform.position, interactRange);
                foreach (Collider collider in colliderArray)
                {
                    if (collider.transform.TryGetComponent(out objectInteractable))
                    {
                        objectInteractable.Drop();
                        objectInteractable = null;
                        Debug.Log("Dropped");
                    }
                }
            }
        }
    }





    public ObjectInteractable GetInteractableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(playerCameraTransform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ObjectInteractable objInteractable))
            {
                return objInteractable;
            }
        }
        return null;
    }

}
