using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReputation : MonoBehaviour
{
    Reputation _reputation;

    [SerializeField] Image _bar;
    SoundManager _soundManager;
    float currentValue = 0;

    Color _basicColor;
    Color _currentColor = Color.white;

    int colorSens = 1;


    private void Start()
    {
        _soundManager = GameObject.FindAnyObjectByType<SoundManager>();
        _basicColor = _bar.color;
        _currentColor = _basicColor;
        _reputation = GameObject.FindFirstObjectByType<Reputation>();
        currentValue = _reputation.ReputationValue;
    }

    private void Update()
    {
        if(currentValue != _reputation.ReputationValue)
        {
            float dir = _reputation.ReputationValue - currentValue;
            currentValue += dir * Time.deltaTime;
            _bar.fillAmount = currentValue / 100.0f + 0.1f;
        }

        if(currentValue < 30)
        {
            if(_soundManager)
                _soundManager.SetPitchMusic(1.25f);
            if (colorSens == 1)
            {
                //direction Red Color
                Color dir = Color.red - _currentColor;
                _currentColor += dir * Time.deltaTime * 8.0f;
                _bar.color = _currentColor;
                if(_currentColor.r >= Color.red.r - 0.1f)
                {
                    colorSens = -1;
                }
            }

            if (colorSens == -1)
            {
                //direction Basic Color
                Color dir = _basicColor - _currentColor;
                _currentColor += dir * Time.deltaTime * 8.0f;
                _bar.color = _currentColor;
                if (_currentColor.b >= _basicColor.b - 0.1f)
                {
                    colorSens = 1;
                }
            }

        }

        if (currentValue >= 30)
        {
            if(_soundManager)
                _soundManager.SetPitchMusic(1f);
            _bar.color = _basicColor;
        }
    }
}
