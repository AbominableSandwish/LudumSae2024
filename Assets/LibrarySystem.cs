using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibrarySystem : MonoBehaviour
{

    [SerializeField]List<GameObject> books;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockBook(RequestSystem.resolution resolution)
    {
        books[(int)resolution].SetActive(true);
    }
}
