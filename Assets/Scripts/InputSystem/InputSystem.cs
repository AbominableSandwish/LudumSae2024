using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    
    private PlayerControls _playerControls;
    private InGame _ui;
    private GameManager _gameManager;
    private List<Directions> _enteredInputs = new List<Directions>();

    bool _canSpell = true;

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
        _ui = GameObject.Find("UIArrowSpell").GetComponent<InGame>();
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
        if (_canSpell)
        {
            _enteredInputs.Add(Directions.Up);
            _ui.NewInput(Directions.Up);
        }
    }
    
    private void Right()
    {
        if(_canSpell)
        {
            _enteredInputs.Add(Directions.Right);
            _ui.NewInput(Directions.Right);
        }
    }
    
    private void Down()
    {
        if (_canSpell)
        {
            _enteredInputs.Add(Directions.Down);
            _ui.NewInput(Directions.Down);
        }
    }
    
    private void Left()
    {
        if (_canSpell)
        {
            _enteredInputs.Add(Directions.Left);
            _ui.NewInput(Directions.Left);
        }   
    }

    public void InputSpellLock()
    {
        _canSpell = false;
    }

    public void InputSpellUnLock()
    {
        _canSpell = true;
    }
}
