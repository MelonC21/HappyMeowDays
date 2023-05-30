using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool gameISPaused;
    [SerializeField]
    private GameObject PauseMenuUI;

    [SerializeField]
    private bool settingsIsOpen = false;
    [SerializeField]
    private GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameISPaused = false;
        PauseMenuUI.SetActive(false);
        settingsIsOpen = false;
        settingsMenu.SetActive(false);
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
                settingsIsOpen = false;
                settingsMenu.SetActive(false);
            }
        }

        
    }

    public void ToggleSettings()
    {
        if (settingsIsOpen)
        {
            settingsIsOpen = false;
            settingsMenu.SetActive(false);

        }
        else if (!settingsIsOpen)
        {
            settingsIsOpen = true;
            settingsMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        gameISPaused = false;
        PauseMenuUI.SetActive(false);

    }

    public void MainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Reset()
    {
        gameISPaused = false;
        PauseMenuUI.SetActive(false);
        settingsIsOpen = false;
        settingsMenu.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
