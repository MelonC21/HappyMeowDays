using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{

    RaycastHit hitInfo;

    public LineView lineView;
    public DialogueRunner dialogueRunner;

    private bool playerInRange = false;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange || dialogueRunner.Dialogue.IsActive)
        {
            DialogueIsReady();
        }
    }

    private void DialogueIsReady()
    {
        //Debug.Log("Dialogue is ready");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueRunner.Dialogue.IsActive)
            {
                dialogueRunner.StartDialogue("alien");

                //Debug.Log(dialogueRunner.Dialogue);
            }
            else
            {
                lineView.UserRequestedViewAdvancement();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;

            Debug.Log("entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;

            Debug.Log("exit");
        }
    }
}
