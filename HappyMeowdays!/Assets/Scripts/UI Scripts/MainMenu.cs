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
    

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SettingsButton()
    {
        if (settingsIsOpen)
        {
            settingsIsOpen = false;


        }else if(!settingsIsOpen)
        {
            settingsIsOpen = true;
        }
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}
