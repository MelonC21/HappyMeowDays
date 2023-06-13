using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager Instance;
    public GameState State;

    [SerializeField]
    public enum GameState
    {
        Menu,
        Playing,
        Paused
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

    }

    public void UpdateGamestate(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Menu:
                break;
            case GameState.Playing:
                Playing();
                break;
            case GameState.Paused:
                Paused();
                break;
            default:
                break;
        }
    }

    private void Paused()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Playing()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
