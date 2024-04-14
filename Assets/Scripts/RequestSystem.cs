using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



public class RequestSystem : MonoBehaviour
{
    CharacterManager _characterManager;
    SpellManager _spellManager;


    public class Request
    {
        public resolution _resolution;
        public int _difficulty;

        public Request(resolution resolution, int difficulty = 1)
        {
            this._resolution = resolution;
            this._difficulty = difficulty;
        }
    }

   
    private List<Request> _requests;
    public int  NbrRequest = 0;

    private scoreSystem _score;
    public enum resolution
    {
        Pickle = 0,
        Lens = 1,
        Invisible = 2,
        Tongue = 3,
        metamorphosis = 4,
        Hurt = 5,  
    }
   


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("score"))
            _score = GameObject.Find("score").GetComponent<scoreSystem>();
        if (GameObject.Find("SpellManager"))
            _spellManager = GameObject.Find("SpellManager").GetComponent<SpellManager>();
        if (GameObject.Find("Peeps"))
            _characterManager = GameObject.Find("Peeps").GetComponent<CharacterManager>();
        _requests = new List<Request>();

       
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpellSucess(resolution spell)
    {
        if(_requests.Count != 0) {
            //Sucess
            if (_requests[0]._resolution == resolution.Hurt)
            {
                Debug.Log("Success");
                _score.SucessScore(_requests[0]._difficulty);
                
                _characterManager.FreePeep(true);
            }

           
            //Failure
            if (_requests[0]._resolution != resolution.Hurt)
            {
                _score.FailureScore();
                _characterManager.FreePeep(false);
            }

            _requests.Remove(_requests[0]);
            NbrRequest = _requests.Count;

            if (_requests.Count != 0)
                GameObject.Find("SpeechBubble").GetComponent<UIBubble>().SetComplaints(_requests[0]._resolution);
        }
    }

    public void SpellFailure()
    {
        if (_requests.Count != 0)
        {
            //Failure
            _score.FailureScore();
            _requests.Remove(_requests[0]);
            NbrRequest = _requests.Count;
            _characterManager.FreePeep(false);
            
            if (_requests.Count != 0)
                GameObject.Find("SpeechBubble").GetComponent<UIBubble>().SetComplaints(_requests[0]._resolution);
        }
    }
    public void NewRequest()
    {
        _characterManager.NewPeep();
        List<Spell> spells = _spellManager.GetSpellUnlocked();
        int rdm = Random.Range(0, spells.Count);
        _requests.Add(new Request(spells[rdm].resolution));
        NbrRequest = _requests.Count;

        if (_requests.Count == 1)
            GameObject.Find("SpeechBubble").GetComponent<UIBubble>().SetComplaints(spells[rdm].resolution);
        if (_requests.Count == 10)
        {
            SceneManager.LoadScene("MenuScore");
        }
    }
}
