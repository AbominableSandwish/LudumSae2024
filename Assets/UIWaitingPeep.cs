using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWaitingPeep : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    [SerializeField] Image _paper;

    Animator _animator;

    int _nbrPeepWaiting;

    Color _basicColor;
    Color _currentColor;
    int colorSens = 1;

    RequestSystem _requestSystem;
    private void Start()
    {
        _requestSystem = GameObject.FindFirstObjectByType<RequestSystem>();
        _animator = GetComponent<Animator>();
        _basicColor = _paper.color;

        _nbrPeepWaiting = _requestSystem.NbrRequest;
    }
    // Update is called once per frame
    void Update()
    {
        if(_nbrPeepWaiting != _requestSystem.NbrRequest)
        {
            _nbrPeepWaiting = _requestSystem.NbrRequest;
            _animator.Play("Event");
        }
        if (_requestSystem)
        {
            _text.text = _requestSystem.NbrRequest.ToString();
        }

        if (_requestSystem.NbrRequest >= 4)
        {
            if (colorSens == 1)
            {
                //direction Red Color
                Color dir = Color.red - _currentColor;
                _currentColor += dir * Time.deltaTime * 8.0f;
                _paper.color = _currentColor;
                if (_currentColor.r >= Color.red.r - 0.1f && _currentColor.b <= 0.1f)
                {
                    colorSens = -1;
                }
            }

            if (colorSens == -1)
            {
                //direction Basic Color
                Color dir = _basicColor - _currentColor;
                _currentColor += dir * Time.deltaTime * 8.0f;
                _paper.color = _currentColor;
                if (_currentColor.b >= _basicColor.b - 0.1f & _currentColor.g >= _basicColor.g - 0.1f)
                {
                    colorSens = 1;
                }
            }

        }

        if (_requestSystem.NbrRequest < 4)
        {
            _paper.color = _basicColor;
        }
    }
}
