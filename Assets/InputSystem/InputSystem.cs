using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    
    private PlayerControls _playerControls;
    private GameManager _gameManager;
    private List<Directions> _enteredInputs = new List<Directions>();

    public List<Directions> EnteredInputs
    {
        get => _enteredInputs;
        set => _enteredInputs = value;
    }

    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _playerControls = new PlayerControls();
    }
    
    private void Start()
    {
        //Subscribe to Button type actions
        _playerControls.Player.Pause.performed += _ => Pause();
        _playerControls.Player.Up.performed += _ => Up();
        _playerControls.Player.Right.performed += _ => Right();
        _playerControls.Player.Down.performed += _ => Down();
        _playerControls.Player.Left.performed += _ => Left();
    }
    
    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        if (_playerControls != null)
            _playerControls.Disable();
    }
    
    private void Pause()
    {
        _gameManager.SetPause();
    }
    
    private void Up()
    {
        _enteredInputs.Add(Directions.Up);
    }
    
    private void Right()
    {
        _enteredInputs.Add(Directions.Right);
    }
    
    private void Down()
    {
        _enteredInputs.Add(Directions.Down);
    }
    
    private void Left()
    {
        _enteredInputs.Add(Directions.Left);
    }
}
