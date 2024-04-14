using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class Spell
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
    public static Spell OpenPickle(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Up);
        incantation.Add(Directions.Down);
        incantation.Add(Directions.Up);
        incantation.Add(Directions.Down);

        return new Spell(id, "Open Pickle", "Clap", incantation, RequestSystem.resolution.Pickle);
    }
    public static Spell Lens(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Right);
        incantation.Add(Directions.Left);
        incantation.Add(Directions.Right);
        incantation.Add(Directions.Left);

        return new Spell(id, "Search", "AHHHHHHHH", incantation, RequestSystem.resolution.Lens);
    }
  

    public static Spell Tongue(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Down);
        incantation.Add(Directions.Down);
        incantation.Add(Directions.Up);
        incantation.Add(Directions.Down);

        return new Spell(id, "Language", "Blabla", incantation, RequestSystem.resolution.Tongue);
    }

    public static Spell Invisible(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Left);
        incantation.Add(Directions.Left);
        incantation.Add(Directions.Right);
        incantation.Add(Directions.Right);

        return new Spell(id, "Invisible", "Blabla", incantation, RequestSystem.resolution.Invisible);
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

    public static Spell Metamorphosis(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Down);
        incantation.Add(Directions.Up);
        incantation.Add(Directions.Right);
        incantation.Add(Directions.Left);

        return new Spell(id, "Metamorphosis", "Atcha", incantation, RequestSystem.resolution.metamorphosis);
    }
}





public class SpellManager : MonoBehaviour
{
    InputSystem _inputmanager;
    RequestSystem _requestSystem;
    SoundManager _soundmanager;
    LibrarySystem _librarysystem;
    InGame _ui;

    List<Spell> spells;
    List<Spell> spellsDetected;

    List<Spell> _spellsLocked;
    List<Spell> _spellsUnlocked;
    bool isSearch = false;

    public Spell GetSpell(int id)
    {
        Spell spell_to_return = null;
        foreach (Spell spell in spells)
        {
            if (spell.id == id)
            {
                spell_to_return =  spell;
            }
        }
        return spell_to_return;
    }

    public Spell GetSpell(RequestSystem.resolution res)
    {
        Spell spell_to_return = null;
        foreach (Spell spell in spells)
        {
            if (spell.resolution == res)
            {
                spell_to_return = spell;
            }
        }
        return spell_to_return;
    }

    // Start is called before the first frame update
    void Start()
    {

        _ui = GameObject.Find("UI").GetComponent<InGame>();
        _inputmanager = GameObject.Find("InputSystem").GetComponent<InputSystem>();
        _requestSystem = GameObject.Find("RequestSystem").GetComponent<RequestSystem>();
        _librarysystem = GameObject.Find("Bookshelf").GetComponent<LibrarySystem>();

        if (GameObject.Find("SoundManager"))
            _soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        spells = new List<Spell>();
        spellsDetected = new List<Spell>();


        _spellsLocked = new List<Spell>();
        _spellsUnlocked = new List<Spell>();
        _spellsLocked.Add(Spell.OpenPickle(spells.Count));
        _spellsLocked.Add(Spell.Heal(spells.Count));
        _spellsLocked.Add(Spell.Invisible(spells.Count));
        _spellsLocked.Add(Spell.Lens(spells.Count));
        _spellsLocked.Add(Spell.Metamorphosis(spells.Count));
        _spellsLocked.Add(Spell.Tongue(spells.Count));

        while(_spellsUnlocked.Count != 3)
        {
            int rdm = UnityEngine.Random.Range(0, _spellsLocked.Count-1);

            _spellsUnlocked.Add(_spellsLocked[rdm]);
            _librarysystem.UnlockBook(_spellsLocked[rdm].resolution);
            _spellsLocked.RemoveAt(rdm);
        }

        foreach(Spell spell in _spellsUnlocked)
        {
            spells.Add(spell);
            
        }

    }

    public void UnlockNewSpell()
    {
        int rdm = UnityEngine.Random.Range(0, _spellsLocked.Count - 1);
        _spellsUnlocked.Add(_spellsLocked[rdm]);
        _librarysystem.UnlockBook(_spellsLocked[rdm].resolution);
        spells.Add(_spellsLocked[rdm]);
        _spellsLocked.RemoveAt(rdm);
    }

    public List<Spell> GetSpellUnlocked()
    {
        return _spellsUnlocked;
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
                    if (_soundmanager)
                        _soundmanager.PlaySound(SoundManager.Sound.SpellSucess);
                    if (_requestSystem.NbrRequest != 0)
                    {
                        _requestSystem.SpellSucess(spellsDetected[0].resolution);
                       
                    }
                    spellsDetected.Clear();
                    isSearch = false;
                    _ui.Action();
                    return;
                }
            }

            //Failure
            if (spellsDetected.Count == 0)
            {
                _inputmanager.EnteredInputs.Clear();
                if(_soundmanager)
                    _soundmanager.PlaySound(SoundManager.Sound.SpellFailure);
                if (_requestSystem.NbrRequest != 0)
                {
                    _requestSystem.SpellFailure();
                    
                }
                isSearch = false;
                _ui.Clear();
                return;
            }
        }
    }
}
