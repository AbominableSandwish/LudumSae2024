using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _parametre;
    [SerializeField] private GameObject _TextPause;
    public bool IsParametre;
    
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        if (_gameManager.IsPaused)
        {
            _pause.SetActive(true);
            _parametre.SetActive(IsParametre);
            if (IsParametre)
            {
                _TextPause.SetActive(false);
            }
            else
            {
                _TextPause.SetActive(true);
            }
        }
        else
        {
            IsParametre = false;
            _pause.SetActive(false);
            _parametre.SetActive(false);
        }
        
        
    }

    public void boolIsParametre()
    {
        IsParametre = !IsParametre;
    }
        
    
}
