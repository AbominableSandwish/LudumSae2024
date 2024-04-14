using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI peep;
    [SerializeField] private TextMeshProUGUI sucess;
    [SerializeField] private TextMeshProUGUI Failure;
    [SerializeField] private TextMeshProUGUI combo_max;
    [SerializeField] private TextMeshProUGUI score;
    
    
     private string _peep;
     private string _sucess;
     private string _Failure;
     private string _combo_max;
     private string _score;

    private scoreSystem _SS;
    void Start()
    {
        _SS = FindFirstObjectByType<scoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _peep = _SS.Peep.ToString();
        _sucess = _SS.MaxSucess.ToString();
        _Failure = _SS.MaxFaillure.ToString();
        _combo_max = _SS.MaxCombofinal.ToString();
        _score = _SS.Score.ToString();

        peep.text = _peep;
        sucess.text = _sucess;
        Failure.text = _Failure;
        combo_max.text = _combo_max;
        score.text = _score;
    }
}
