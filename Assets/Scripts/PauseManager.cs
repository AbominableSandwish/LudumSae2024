using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _parametre;
    [SerializeField] private GameObject _TextPause;

    [SerializeField] private Slider _sliderMaster;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSound;
    [SerializeField] private Slider _sliderVoice;
    [SerializeField] private Slider _sliderUI;

    SoundManager _soundManager;
    public bool IsParametre;
    
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _soundManager = FindFirstObjectByType<SoundManager>();

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

        if (_soundManager)
        {
            _soundManager.SetVolume(SoundManager.Type.Master, (int)_sliderMaster.value);
            _soundManager.SetVolume(SoundManager.Type.Music, (int)_sliderMusic.value);
            _soundManager.SetVolume(SoundManager.Type.Sound, (int)_sliderSound.value);
            _soundManager.SetVolume(SoundManager.Type.Menu, (int)_sliderSound.value);
        }
    }

    public void boolIsParametre()
    {
        IsParametre = !IsParametre;
    }

}
