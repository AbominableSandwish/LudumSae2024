using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Reputation : MonoBehaviour
{
    private int _reputationValue;
    private int _queueSize;
    private int _maxQueueSize;
    private GameManager _gameManager;
    // private bool _coroutineRunning = true;
    
    public int ReputationValue
    {
        get => _reputationValue;
        set => _reputationValue = value;
    }

    int accumationReputation = 0;
    int _levelReputation = 0;
    const int MAX_LEVEL_REPUTATION = 3;

    private void Start()
    {
        ReputationValue = 100;
        accumationReputation += ReputationValue;
    }

    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    public void LoseReputation(int quantity)
    {
        _reputationValue -= quantity;
        // Check Game Over
        if (_reputationValue < 0)
        {
            _gameManager.SetGameState(GameManager.GameState.GameOver);
        }
    }


    public void GainReputation(int quantity)
    {
        _reputationValue += quantity;
        if(_reputationValue > 100)
        {
            _reputationValue = 100;
        }
        accumationReputation += quantity;
        CheckUpgrade();
    }

    private int _prevFib = 3;
    private int _nextFib = 5;
    private int _counterReputation = 0;

    public void CheckUpgrade()
    {
        if (CheckFibonaci(_counterReputation))
        {
            _levelReputation++;
            GameObject.FindFirstObjectByType<SpellManager>().UnlockNewSpell();
            //GameObject.FindFirstObjectByType<EvenementSystem>().AddNewTimer();
        }
    }

    private int _scale = 50;
    bool CheckFibonaci(int current)
    {
        bool isUp = false;
        if (current >= _nextFib * _scale)
        {
            int sum = _prevFib + _nextFib;
            _prevFib = _nextFib;
            _nextFib = sum;
            isUp = true;
        }

        return isUp;
    }

}