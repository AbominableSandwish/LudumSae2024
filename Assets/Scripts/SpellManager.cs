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

    public List<Directions> incantation;

    public Spell(int id, string name, string description, List<Directions> incantation)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.incantation = incantation;
    }
    public static Spell Water(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Up);
        incantation.Add(Directions.Down);
        incantation.Add(Directions.Up);
        incantation.Add(Directions.Down);

        return new Spell(id, "Water", "GlouGLou", incantation);
    }
    public static Spell Fire(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Right);
        incantation.Add(Directions.Left);
        incantation.Add(Directions.Right);
        incantation.Add(Directions.Left);

        return new Spell(id, "Fire", "AHHHHHHHH", incantation);
    }
    public static Spell Heal(int id)
    {
        List<Directions> incantation = new List<Directions>();

        incantation.Add(Directions.Left);
        incantation.Add(Directions.Up);
        incantation.Add(Directions.Right);
        incantation.Add(Directions.Down);

        return new Spell(id, "Heal", "Ohhhhhh", incantation);
    }

}





public class SpellManager : MonoBehaviour
{
    InputSystem manager;

    List<Spell> spells;
    List<Spell> spellsDetected;
    bool isSearch = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("InputSystem").GetComponent<InputSystem>();
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
        List<Directions> inputBuffer = manager.EnteredInputs;
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
                    Debug.Log("Success");
                    manager.EnteredInputs.Clear();
                    spellsDetected.Clear();
                    isSearch = false;
                    return;
                }
            }

            //Failure
            if (spellsDetected.Count == 0)
            {
                Debug.Log("Failure");
                manager.EnteredInputs.Clear();
                isSearch = false;
                return;
            }
        }
    }
}
