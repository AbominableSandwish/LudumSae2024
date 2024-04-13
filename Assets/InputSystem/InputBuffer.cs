using System;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{
    private InputSystem _inputSystem;
    
    //Current Spell Length
    private int _currentSpellLength;

    private void Start()
    {
        _inputSystem = GetComponent<InputSystem>();
    }

    private void Update()
    {
        //Input Buffer starts every new event
        //_inputSystem.EnteredInputs.Clear();
        if (_inputSystem.EnteredInputs.Count > _currentSpellLength)
        {
            //FAILURE
        }
    }

    public void Failure()
    {
        _inputSystem.EnteredInputs.Clear();
    }

    public void Success()
    {
        _inputSystem.EnteredInputs.Clear();
    }
}
