using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpellUi : MonoBehaviour
{
    InputSystem _inputSystem;
    Animator _animator;

    private void Start()
    {
        _inputSystem = GameObject.Find("InputSystem").GetComponent<InputSystem>();

        _animator = GetComponent<Animator>();
    }
    public void Failure() {
        _animator.SetTrigger("Failure");
    }

    public void Success() {
        _animator.SetTrigger("Sucess");
    }

    public void Unlock()
    {
        _inputSystem.InputSpellUnLock();
    }
}
