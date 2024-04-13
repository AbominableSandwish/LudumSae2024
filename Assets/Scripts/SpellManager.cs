using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

enum KeyInput
{
    UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3
}


class InputManager
{
    List<KeyInput> InputBuffer;
    InputManager()
    {
        this.InputBuffer = new List<KeyInput>();
    }

    void AddInput(KeyInput key)
    {
        InputBuffer.Add(key);
    }
    public List<KeyInput> GetBuffer()
    {
        return InputBuffer;
    }

};
class Spell
{
    public int id;
    public string name;
    public string description;

    public List<KeyInput> incantation;

    public Spell(int id, string name, string description, List<KeyInput> incantation)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.incantation = incantation;
    }
    public static Spell Water(int id)
    {
        List<KeyInput> incantation = new List<KeyInput>();

        incantation.Add(KeyInput.UP);
        incantation.Add(KeyInput.DOWN);
        incantation.Add(KeyInput.UP);
        incantation.Add(KeyInput.DOWN);

        return new Spell(id, "Water", "GlouGLou", incantation);
    }
    public static Spell Fire(int id)
    {
        List<KeyInput> incantation = new List<KeyInput>();

        incantation.Add(KeyInput.RIGHT);
        incantation.Add(KeyInput.LEFT);
        incantation.Add(KeyInput.RIGHT);
        incantation.Add(KeyInput.LEFT);

        return new Spell(id, "Fire", "AHHHHHHHH", incantation);
    }
    public static Spell Heal(int id)
    {
        List<KeyInput> incantation = new List<KeyInput>();

        incantation.Add(KeyInput.LEFT);
        incantation.Add(KeyInput.UP);
        incantation.Add(KeyInput.RIGHT);
        incantation.Add(KeyInput.DOWN);

        return new Spell(id, "Heal", "Ohhhhhh", incantation);
    }
}





public class SpellManager : MonoBehaviour
{





    List<Spell> spells;

    InputManager manager;

    List<Spell> spellsDetected;
    bool isSearch = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("InputManager").GetComponent<InputManager>();

        for (int i = 0; i < 3; i++) {
            spells.Add(Spell.Heal(spells.Count));
            spells.Add(Spell.Water(spells.Count));
            spells.Add(Spell.Fire(spells.Count));
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputBuffer();
    }

    void CheckInputBuffer()
    {
        List<Spell> toRemove = new List<Spell>();
        List<KeyInput> inputBuffer = manager.GetBuffer();
        if (spellsDetected.Count == 0)
        {
            if(inputBuffer.Count != 0)
            {
                spellsDetected = new List<Spell>();
                spellsDetected = spells;
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
                Debug.Log("Succes");
                //Input clear
                isSearch = false;
            }

            //Failure
            if (spellsDetected.Count == 0)
            {
                Debug.Log("Failure");
                //Input clear
                isSearch = false;
            }
        }
    }
}
