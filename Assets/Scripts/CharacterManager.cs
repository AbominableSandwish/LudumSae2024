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
        GameObject peep = PeepsFree.Dequeue();
        peep.SetActive(true);
        peep.transform.localPosition += new Vector3(0, 10, 0);
        peep.GetComponent<CharacterSpawner>().SpawnCharacter();
        peep.GetComponent<Animator>().Play("Enter");
        PeepsUsed.Enqueue(peep);
    }
    public void FreePeep()
    {
        GameObject peep = PeepsUsed.Dequeue();
        peep.GetComponent<Animator>().Play("Exit");
        PeepsFree.Enqueue(peep);
    }
}
