using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutManager : MonoBehaviour
{
    public void LoadScene(string name)
    {
        GameObject.Find("SceneManager").GetComponent<LevelLoader>().LoadScene(name);
        Destroy(GameObject.Find("SceneSystem"));
    }
}
