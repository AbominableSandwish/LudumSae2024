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

        //Input Buffer starts every new event
        //Spell Manager will call either Failure OR Success to reset the list

    public void Failure()
    {
        _inputSystem.EnteredInputs.Clear();
    }

    public void Success()
    {
        _inputSystem.EnteredInputs.Clear();
    }
}
