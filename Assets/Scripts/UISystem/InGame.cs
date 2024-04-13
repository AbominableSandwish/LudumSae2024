using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> _arrowsFree;
    [SerializeField] List<GameObject> _arrowsUsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewInput(Directions dir)
    {
        GameObject arrow = _arrowsFree[_arrowsFree.Count - 1];
        switch (dir)
        {
            case Directions.Up:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(270, Vector3.forward);
                break; 
            case Directions.Down:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(90, Vector3.forward);
                break;
            case Directions.Left:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(0, Vector3.forward);
                break;
            case Directions.Right:
                arrow.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(180, Vector3.forward);
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
        foreach (GameObject arrow in _arrowsUsed)
        {
            arrow.transform.localPosition = new Vector3(0, -150, 0);
            _arrowsFree.Add(arrow);
            
        }
        _arrowsUsed.Clear();
    }
}
