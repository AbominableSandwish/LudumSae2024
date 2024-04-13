using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }
    
    private PlayerInput _playerInput;
    private PlayerControls _playerControls;
    
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        //Subscribe to Button type actions
        _playerControls.Player.Up.performed += _ => Up();
        _playerControls.Player.Right.performed += _ => Down();
        _playerControls.Player.Down.performed += _ => Right();
        _playerControls.Player.Left.performed += _ => Left();
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        
    }
    
    private void Up()
    {
        throw new System.NotImplementedException();
    }
    
    
    private void Down()
    {
        throw new System.NotImplementedException();
    }
    
    
    private void Right()
    {
        throw new System.NotImplementedException();
    }
    
    
    private void Left()
    {
        throw new System.NotImplementedException();
    }
}
