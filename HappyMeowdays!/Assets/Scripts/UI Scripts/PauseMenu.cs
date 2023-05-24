using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool gameISPaused;
    [SerializeField]
    private GameObject PauseMenuUI;
    [SerializeField]
    private ButtonControl resume;
   

    // Start is called before the first frame update
    void Start()
    {
        gameISPaused = false;
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gameISPaused)
            {
                gameISPaused = true;
                PauseMenuUI.SetActive(true);
            }
            else
            {
                gameISPaused = false;
                PauseMenuUI.SetActive(false);
            }
        }

        
    }

    public void Resume()
    {
        gameISPaused = false;
        PauseMenuUI.SetActive(false);

    }
}
