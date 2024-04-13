using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Reputation : MonoBehaviour
{
    [Range(0, 1)] private float _reputationValue = 0.5f;
    private int _queueSize;
    private int _maxQueueSize;
    private GameManager _gameManager;
    
    public float ReputationValue
    {
        get => _reputationValue;
        set => _reputationValue = value;
    }
    
    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        //If reputation reaches 0 or the queue becomes too big, GameOver
        if (_reputationValue == 0 || _queueSize >= _maxQueueSize)
        {
            _gameManager.SetGameState(GameManager.GameState.GameOver);
        }
    }
}