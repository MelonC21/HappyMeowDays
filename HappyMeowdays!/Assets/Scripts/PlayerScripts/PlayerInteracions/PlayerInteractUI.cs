using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    //[SerializeField] private PlayerInteraction2 playerInteract2;
    [SerializeField] private PlayerInteraction playerInteract;
    
    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            //Show(playerInteract.GetInteractableObject());
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        containerGameObject.SetActive(true);
        //interactTextMeshProUGUI.text = objInteractable.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
