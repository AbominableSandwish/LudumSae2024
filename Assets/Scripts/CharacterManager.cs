using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Peeps;
    [SerializeField] Queue<GameObject> PeepsFree;
    Queue<GameObject> PeepsUsed;
    // Start is called before the first frame update
    void Start()
    {
        PeepsFree = new Queue<GameObject>();
        PeepsUsed = new Queue<GameObject>();

        foreach (GameObject p in Peeps) {
            PeepsFree.Enqueue(p);
        } 
    }


    public void NewPeep()
    {
        if (PeepsFree.Count != 0)
        {
            GameObject peep = PeepsFree.Dequeue();
            peep.SetActive(true);
            peep.transform.localPosition += new Vector3(0, 10, 0);
            peep.GetComponent<CharacterSpawner>().SpawnCharacter();
            peep.GetComponent<Animator>().Play("Enter");
            PeepsUsed.Enqueue(peep);
        }
    }
    public void FreePeep(bool success)
    {
        if (PeepsUsed.Count != 0)
        {
            GameObject peep = PeepsUsed.Dequeue();
            if (!success)
            {
                peep.GetComponent<CharacterSpawner>().Eyes.sprite = peep.GetComponent<CharacterSpawner>()
                    .SadEyesList[Random.Range(0, peep.GetComponent<CharacterSpawner>().SadEyesList.Count)];
                peep.GetComponent<CharacterSpawner>().SpellResult.gameObject.SetActive(true);
                peep.GetComponent<Animator>().Play("Exit");
            }
            else
            {
                peep.GetComponent<CharacterSpawner>().Eyes.sprite = peep.GetComponent<CharacterSpawner>().HappyEyes;
                peep.GetComponent<Animator>().Play("HappyPeep");
            }
            PeepsFree.Enqueue(peep);
        }
    }
}
