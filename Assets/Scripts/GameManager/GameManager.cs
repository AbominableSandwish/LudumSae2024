using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Init,
        Menu,
        Game,
        GameOver
    }

    public GameState currentGameState = GameState.Init;
    private Reputation _reputation;
    
    private bool _isPaused = false;
    public bool IsPaused => _isPaused;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Time.timeScale = _isPaused ? 0 : 1;
    }

    public void SetGameState(GameState newState)
    {
        OnStateExit();
        currentGameState = newState;
        OnStateEnter();
    }

    private void OnStateEnter()
    {
        switch (currentGameState)
        {
            case GameState.Init:
                //SceneManager.LoadScene();
                Debug.Log("Init State");
                break;
            case GameState.Menu:
                SceneManager.LoadScene("MainMenu");
                break;
            case GameState.Game:
                break;
            case GameState.GameOver:
                SceneManager.LoadScene("MenuScore");
                break;
        }
    }

    private void OnStateExit()
    {
        switch (currentGameState)
        {
            case GameState.Init:
                Debug.Log("Exiting Init State");
                break;
            case GameState.Menu:
                break;
            case GameState.Game:
                break;
            case GameState.GameOver:
                break;
        }
    }

    public void SetPause()
    {
        _isPaused = !_isPaused;
    }

    public void Exit()
    {
        SetGameState(GameState.Menu);
    }
    
}