using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RequestSystem : MonoBehaviour
{
    CharacterManager _characterManager;
    SpellManager _spellManager;
    SoundManager _soundManager;
    private ParticleSystem _particleSystem;
    Reputation _reputation;


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
        if (GameObject.Find("SoundManager"))
            _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (GameObject.Find("FeatherExplosion"))
            _particleSystem = GameObject.Find("FeatherExplosion").GetComponent<ParticleSystem>();

        _reputation = GameObject.FindFirstObjectByType<Reputation>();
        _requests = new List<Request>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_soundManager)
        {
            if (_requests.Count >= 4)
            {
                _soundManager.SetPitchMusic(1.25f);
            }

            if (_requests.Count < 4)
            {
                _soundManager.SetPitchMusic(1);
            }
        }
    }

    public void SpellSucess(resolution spell)
    {
        if(_particleSystem)
            _particleSystem.Play();
        GameObject currentPeep = _characterManager.CurrentPeep;
        //Existing spell
        if(_requests.Count != 0) {
            //Sucess
            if (_requests[0]._resolution == spell)
            {
                currentPeep.GetComponent<CharacterSpawner>().SetSpellResult(spell, true);
                _score.SucessScore(_requests[0]._difficulty);

                _reputation.GainReputation(20);
                _characterManager.FreePeep(true);
                
            }
   
            //Failure
            if (_requests[0]._resolution != spell)
            {
                currentPeep.GetComponent<CharacterSpawner>().SetSpellResult(spell, false);
                _score.FailureScore();
                
               

                _reputation.LoseReputation(10);
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
        if(_particleSystem)
            _particleSystem.Play();
        if (_requests.Count != 0)
        {
            GameObject currentPeep = _characterManager.CurrentPeep;
            currentPeep.GetComponent<CharacterSpawner>().SpellFailed();
            //Failure
            _score.FailureScore();
            _requests.Remove(_requests[0]);
            NbrRequest = _requests.Count;
            _characterManager.FreePeep(false);
            _reputation.LoseReputation(30);
           
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
        if (_requests.Count == 6)
        {
            _soundManager.SetPitchMusic(1);
            SceneManager.LoadScene("MenuScore");
        }
    }
}
