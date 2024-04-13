using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookSpell : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    [SerializeField] private Image _imageSpell_0;
    [SerializeField] private Image _imageSpell_1;
    [SerializeField] private TextMeshPro _title;
    [SerializeField] private TextMeshPro _description;

    [SerializeField] private List<Image> _arrows;
    SpellManager _spellManager;



    // Start is called before the first frame update
    void Start()
    {
        _spellManager = GameObject.Find("SpellManager").GetComponent<SpellManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBook(int id)
    {
       Spell spell = _spellManager.GetSpell(id);

        _title.text = spell.name;
        _description.text = spell.description;

        int i = 0;
        foreach(Directions dir in spell.incantation)
        {
            switch (dir)
            {
                case Directions.Up:
                    _arrows[i].GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(270, Vector3.forward);
                    break;
                case Directions.Down:
                    _arrows[i].GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(90, Vector3.forward);
                    break;
                case Directions.Left:
                    _arrows[i].GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(0, Vector3.forward);
                    break;
                case Directions.Right:
                    _arrows[i].GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(180, Vector3.forward);
                    break;
            }
            i++;
        }
    }

    public void CloseBook()
    {

    }
}
