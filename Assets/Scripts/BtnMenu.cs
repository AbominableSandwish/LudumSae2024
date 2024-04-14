using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMenu : MonoBehaviour
{
    public void MainMenu()
    {
        GameObject.Find("SceneManager").GetComponent<LevelLoader>().LoadScene("MainMenu");
    }
}
