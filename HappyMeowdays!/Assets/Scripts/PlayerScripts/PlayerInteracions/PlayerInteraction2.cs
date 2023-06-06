using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction2 : MonoBehaviour
{
    public List<GameObject> inventory;
    
    public Rigidbody rb;
    public Collider coll;
    public Transform player, objContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (!equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    public void Update()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "Collectable")
            {
                inventory.Add(hitInfo.collider.gameObject);
                Debug.Log(gameObject.name + "Collected!");
                Destroy(hitInfo.collider.gameObject);
            }
        }*/
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out ObjectInteractable objectInteractable))
                {
                    objectInteractable.Interact();
                }
            }
        }*/
        //checking if player is in range of object and "E" is pressed
        /*Vector3 distanceToPlayer = player.position - transform.position;
        if  (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }*/
    }

    /*private void PickUp()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(objContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
    }*/

    public ObjectInteractable GetInteractableObject()
    {
        float interactRange = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ObjectInteractable objectInteractable))
            {
                return objectInteractable;
            }
        }
        return null;
    }
}
