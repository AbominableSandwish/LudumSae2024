using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class RequestSystem : MonoBehaviour
{
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
        Hurt = 2
    }
   


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("ScoreSystem"))
            _score = GameObject.Find("ScoreSystem").GetComponent<scoreSystem>();
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
            }

            //Failure
            if (_requests[0]._resolution != resolution.Hurt)
            {
                _score.FailureScore();
            }

            _requests.Remove(_requests[0]);
            NbrRequest = _requests.Count;
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
        }
    }
    public void NewRequest()
    {
        _requests.Add(new Request(resolution.Hurt));
        NbrRequest = _requests.Count;
    }
}
