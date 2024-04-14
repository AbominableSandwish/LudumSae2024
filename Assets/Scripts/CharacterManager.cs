using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Peeps;
    [SerializeField] Queue<GameObject> PeepsFree;
    Queue<GameObject> PeepsWaiting;
    GameObject currentPeep;

    public GameObject CurrentPeep => currentPeep;
    
    // Start is called before the first frame update
    void Start()
    {
        PeepsFree = new Queue<GameObject>();
        PeepsWaiting = new Queue<GameObject>();

        foreach (GameObject p in Peeps) {
            PeepsFree.Enqueue(p);
        } 
    }


    public void NewPeep()
    {
        if (PeepsFree.Count != 0)
        {
            GameObject peep = PeepsFree.Dequeue();
            PeepsWaiting.Enqueue(peep);

            if(currentPeep == null)
            {
                Peep();
            }
        }
    }

    public void FreePeep(bool success)
    {
       if (currentPeep != null)
       {
          currentPeep.GetComponent<CharacterSpawner>().Eyes.sprite = currentPeep.GetComponent<CharacterSpawner>()
                  .SadEyesList[Random.Range(0, currentPeep.GetComponent<CharacterSpawner>().SadEyesList.Count)];
          if( currentPeep.GetComponent<CharacterSpawner>().SpellResult1 != null)
            currentPeep.GetComponent<CharacterSpawner>().SpellResult1.gameObject.SetActive(true);

          currentPeep.GetComponent<Animator>().Play("Exit");
       }
       else
       {
           currentPeep.GetComponent<CharacterSpawner>().Eyes.sprite = currentPeep.GetComponent<CharacterSpawner>().HappyEyes;
           currentPeep.GetComponent<Animator>().Play("HappyPeep");
       }
       PeepsFree.Enqueue(currentPeep);
       currentPeep = null;

       if (PeepsWaiting.Count != 0)
           Peep();
    }

    public void Peep()
    {
        GameObject peep = PeepsWaiting.Dequeue();
        peep.SetActive(true);
        peep.transform.localPosition += new Vector3(0, 10, 0);
        peep.GetComponent<CharacterSpawner>().SpawnCharacter();
        peep.GetComponent<Animator>().Play("Enter");
        currentPeep = peep;
    }
}
