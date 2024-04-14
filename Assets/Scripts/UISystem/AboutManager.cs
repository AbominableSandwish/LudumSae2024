using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutManager : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
