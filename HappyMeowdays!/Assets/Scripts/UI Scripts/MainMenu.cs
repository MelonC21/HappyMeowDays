using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private bool settingsIsOpen = false;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private bool controlsIsOpen = false;
    [SerializeField]
    private GameObject controlsMenu;

   

    private void Start()
    {
        settingsIsOpen = false;
        settingsMenu.SetActive(false);
        controlsIsOpen = false;
        controlsMenu.SetActive(false);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleSettings()
    {
        if (settingsIsOpen)
        {
            settingsIsOpen = false;
            settingsMenu.SetActive(false);

        }
        else if(!settingsIsOpen)
        {
            settingsIsOpen = true;
            settingsMenu.SetActive(true);
        }
    }

    public void ToggleControls()
    {
        if (controlsIsOpen)
        {
            controlsIsOpen = false;
            controlsMenu.SetActive(false);

        }
        else if (!controlsIsOpen)
        {
            controlsIsOpen = true;
            controlsMenu.SetActive(true);
        }
    }


    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}
