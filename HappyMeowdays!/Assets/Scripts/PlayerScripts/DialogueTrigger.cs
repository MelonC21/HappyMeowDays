using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{

    RaycastHit hitInfo;
    public DialogueRunner dialogueRunner;
    public bool isRunning;

    private void Start()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueRunner.Dialogue.IsActive)
            {
                dialogueRunner.StartDialogue("Start");
            }
        }

        

        }
}
