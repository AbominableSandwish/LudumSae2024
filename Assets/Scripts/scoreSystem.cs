using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreSystem : MonoBehaviour
{

    [SerializeField] private float _score;
    [SerializeField] private float _ComboScore;
    [SerializeField] private float _NumbreComboScore = 1;
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SucessScore(int difficulty)
    {

        switch (_NumbreComboScore)
        {
            case 1:
            case 2:
            case 3:
                _ComboScore = 1f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                break;
            case 4:
                _ComboScore = 1.2f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                break;
            case 5:
                _ComboScore = 1.4f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                
                break;
            case 6:
                _ComboScore = 1.6f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                
                break;
            case 7:
                _ComboScore = 1.8f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                
                break;
            case 8:
                _ComboScore = 2f;
                _score += difficulty * _ComboScore;
                
                break;
                
        }
        
    }
    
    public void FailureSrore()
    {
        _NumbreComboScore = 1;
        
    }
    
    
}
