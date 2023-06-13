using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenutest : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Escape) && !(GameManager.Instance.State == GameManager.GameState.Menu))
        {
            if(!gameISPaused)
            {
                gameISPaused = true;
                PauseMenuUI.SetActive(true);
                GameManager.Instance.UpdateGamestate(GameManager.GameState.Paused);
            }
            else
            {
                gameISPaused = false;
                PauseMenuUI.SetActive(false);
                settingsIsOpen = false;
                settingsMenu.SetActive(false);
                GameManager.Instance.UpdateGamestate(GameManager.GameState.Playing);
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
        GameManager.Instance.UpdateGamestate(GameManager.GameState.Playing);
        
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
