using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    //[SerializeField] private PlayerInteraction2 playerInteraction;
    //[SerializeField] private GameObject containerGameObject;
    /*private void Start()
    {
        playerInteraction = PlayerInteraction;
    }*/

    //public List<GameObject> inventory;
    //Transform interactorTransform
    public void Interact(){
        Debug.Log("touch");
        /*inventory.Add(GameObject.FindGameObjectWithTag("Collectable"));
        Destroy(GetComponent<Collider>().gameObject);*/
    }
}
