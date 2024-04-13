using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> _arrowsFree;
    [SerializeField] List<GameObject> _arrowsUsed;

    List<GameObject> _arrowsToRemove;
    List<GameObject> _arrowsInAction;
    // Start is called before the first frame update
    void Start()
    {
        _arrowsInAction = new List<GameObject>();
        _arrowsToRemove = new List<GameObject>();  
    }

    // Update is called once per frame
    bool _isRemove = false;
    bool _isAction = false;
    float counter_to_remove = 0;
    float counter_to_action = 0;
    void Update()
    {
        if (_isRemove)
        {
            foreach (GameObject arrow in _arrowsToRemove)
            {
                arrow.transform.localPosition = arrow.transform.localPosition - new Vector3(0, 60.0f * Time.deltaTime, 0);
                arrow.GetComponent<Image>().color = arrow.GetComponent<Image>().color - new Color(0, 0, 0, Time.deltaTime);
            }

            counter_to_remove -= Time.deltaTime;
            if (counter_to_remove <= 0.0f)
            {
                CleanArrows();
                _isRemove = false;
            }
        }

        if (_isAction)
        {
            foreach (GameObject arrow in _arrowsInAction)
            {
                arrow.transform.localPosition = arrow.transform.localPosition + new Vector3(0, 30f * Time.deltaTime, 0);
                arrow.GetComponent<Image>().color = arrow.GetComponent<Image>().color - new Color(0, 0, 0, Time.deltaTime);
            }

            counter_to_action -= Time.deltaTime;
            if (counter_to_action <= 0.0f)
            {
                CleanAction();
                _isAction = false;
            }
        }
    }

    public void NewInput(Directions dir)
    {
        GameObject arrow = _arrowsFree[_arrowsFree.Count - 1];
        switch (dir)
        {
            case Directions.Up:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(0, Vector3.forward);
                break; 
            case Directions.Down:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(180, Vector3.forward);
                break;
            case Directions.Left:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(90, Vector3.forward);
                break;
            case Directions.Right:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(270, Vector3.forward);
                break;
        }
       
        _arrowsUsed.Add(arrow);
        
        if(_arrowsUsed.Count != 1)
        {
            int x = 120;
            for(int i = 0; i < _arrowsUsed.Count; i++)
            {
                if (_arrowsUsed.Count % 2 == 1)
                {
                    _arrowsUsed[i].transform.localPosition = new Vector3(x * i - (x * _arrowsUsed.Count / 3), 0, 0);
                }
                else
                {
                    _arrowsUsed[i].transform.localPosition = new Vector3(x * i - (x * _arrowsUsed.Count / 4), 0, 0);
                }              
            }
        }
        else
        {
            arrow.transform.localPosition = new Vector3(0, 0, 0);
        }

        _arrowsFree.Remove(_arrowsFree[_arrowsFree.Count - 1]);
    }

    public void Clear() {
        counter_to_remove = 0.5f;
        _isRemove = true;

        foreach (GameObject arrow in _arrowsUsed)
        {
            _arrowsToRemove.Add(arrow);

        }
        _arrowsUsed.Clear();
    }

    private void CleanArrows()
    {
        foreach (GameObject arrow in _arrowsToRemove)
        {
            arrow.transform.localPosition = new Vector3(0, -150, 0);
            arrow.GetComponent<Image>().color = Color.white;
            _arrowsFree.Add(arrow);
        }
        _arrowsToRemove.Clear();
    }

    public void Action()
    {

        counter_to_action = 1.5f;
        _isAction = true;

        foreach (GameObject arrow in _arrowsUsed)
        {
            _arrowsInAction.Add(arrow);

        }
        _arrowsUsed.Clear();
    }

    private void CleanAction()
    {

        foreach (GameObject arrow in _arrowsInAction)
        {
            arrow.transform.localPosition = new Vector3(0, -150, 0);
            arrow.GetComponent<Image>().color = Color.white;
            _arrowsFree.Add(arrow);

        }
        _arrowsInAction.Clear();
    }
}
