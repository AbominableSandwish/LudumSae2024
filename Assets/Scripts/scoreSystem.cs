using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreSystem : MonoBehaviour
{

    [SerializeField] private float _score;
    [SerializeField] private float _ComboScore;
    [SerializeField] private float _NumbreComboScore = 1;

    [SerializeField]  private int _maxFaillure;
    [SerializeField]  private int _maxSucess;
    [SerializeField]  private int _maxCombo;
    [SerializeField]  private int _maxCombofinal;
    [SerializeField]  private int _peep;

    public int MaxCombofinal => _maxCombofinal;
    public int MaxFaillure => _maxFaillure; 
    public int MaxSucess => _maxSucess;

    public int Peep => _peep;

    public float Score => _score;


    [SerializeField] private GameObject _oeuf;
    [SerializeField] private GameObject _juniorMalefique;
    [SerializeField] private GameObject _JuniorAngelique;


    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (_maxCombo >= 20)
        {
            JuniorAnge();
        }

        if (_maxFaillure >= 20)
        {
            JuniorMalefique();
        }
    }


    public void SucessScore(int difficulty)
    {
        _peep++;
        _maxSucess++;

        switch (_NumbreComboScore)
        {
            case 1:
            case 2:
            case 3:
                _ComboScore = 1f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                _maxCombo++;
                break;
            case 4:
                _ComboScore = 1.2f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                _maxCombo++;
                break;
            case 5:
                _ComboScore = 1.4f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                _maxCombo++;
                
                break;
            case 6:
                _ComboScore = 1.6f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                _maxCombo++;
                
                break;
            case 7:
                _ComboScore = 1.8f;
                _score += difficulty * _ComboScore;
                _NumbreComboScore++;
                _maxCombo++;
                
                break;
            case 8:
                _ComboScore = 2f;
                _score += difficulty * _ComboScore;
                _maxCombo++;
                break;
                
        }
    }
    
    public void FailureScore()
    {

        if (_maxCombo > _maxCombofinal)
        {
            _maxCombofinal = _maxCombo;
            _maxCombo = 0;
        }
        else
        {
            _maxCombo = 0;
        }
        _maxFaillure++;
        _peep++;
        _NumbreComboScore = 1;
        
    }

    private void JuniorAnge()
    {
        _oeuf.SetActive(false);
        _JuniorAngelique.SetActive(true);
    }
    
    private void JuniorMalefique()
    {
        _oeuf.SetActive(false);
        _juniorMalefique.SetActive(true);
    }
    
    
}
