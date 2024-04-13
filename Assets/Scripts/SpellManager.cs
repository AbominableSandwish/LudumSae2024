using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;


class Spell
{
    public int id;
    public string name;
    public string description;
    public RequestSystem.resolution resolution;

    public List<Directions> incantation;

    public Spell(int id, string name, string description, List<Directions> incantation, RequestSystem.resolution resolution)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.incantation = incantation;
        this.resolution = resolution;
    }
    public static Spell Water(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Up);
        incantation.Add(Directions.Down);
        incantation.Add(Directions.Up);
        incantation.Add(Directions.Down);

        return new Spell(id, "Water", "GlouGLou", incantation, RequestSystem.resolution.Hurt);
    }
    public static Spell Fire(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Right);
        incantation.Add(Directions.Left);
        incantation.Add(Directions.Right);
        incantation.Add(Directions.Left);

        return new Spell(id, "Fire", "AHHHHHHHH", incantation, RequestSystem.resolution.Hurt);
    }
    public static Spell Heal(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Left);
        incantation.Add(Directions.Up);
        incantation.Add(Directions.Right);
        incantation.Add(Directions.Down);

        return new Spell(id, "Heal", "Ohhhhhh", incantation, RequestSystem.resolution.Hurt);
    }

}





public class SpellManager : MonoBehaviour
{
    InputSystem _inputmanager;
    RequestSystem _requestSystem;
    InGame _ui;

    List<Spell> spells;
    List<Spell> spellsDetected;
    bool isSearch = false;

    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("UI").GetComponent<InGame>();
        _inputmanager = GameObject.Find("InputSystem").GetComponent<InputSystem>();
        _requestSystem = GameObject.Find("RequestSystem").GetComponent<RequestSystem>();

        spells = new List<Spell>();
        spellsDetected = new List<Spell>();

        spells.Add(Spell.Heal(spells.Count));
        spells.Add(Spell.Water(spells.Count));
        spells.Add(Spell.Fire(spells.Count));
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputBuffer();
    }

    void CheckInputBuffer()
    {
        List<Spell> toRemove = new List<Spell>();
        List<Directions> inputBuffer = _inputmanager.EnteredInputs;
        if (spellsDetected.Count == 0)
        {
            if(inputBuffer.Count != 0)
            {
                spellsDetected = new List<Spell>();
                foreach (Spell spell in spells)
                {
                    spellsDetected.Add(spell);
                }
                isSearch = true;
            }
        }

        if (isSearch)
        {
            //Action
            foreach (Spell spell in spellsDetected) {
               if(spell.incantation[inputBuffer.Count - 1] != inputBuffer[inputBuffer.Count - 1])
                {
                    toRemove.Add(spell);
                }
            }

            if(toRemove.Count != 0)
            {
                foreach (Spell spell in toRemove) {
                    spellsDetected.Remove(spell);
                }
            }

            //Check
            //Success
            if (spellsDetected.Count == 1)
            {
                if (spellsDetected[0].incantation.Count == inputBuffer.Count)
                {
                    _inputmanager.EnteredInputs.Clear();
                    _requestSystem.SpellSucess(spellsDetected[0].resolution);
                    spellsDetected.Clear();
                    isSearch = false;
                    _ui.Clear();
                    return;
                }
            }

            //Failure
            if (spellsDetected.Count == 0)
            {
                _inputmanager.EnteredInputs.Clear();
                _requestSystem.SpellFailure();
                isSearch = false;
                _ui.Clear();
                return;
            }
        }
    }
}
