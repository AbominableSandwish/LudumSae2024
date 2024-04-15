using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ButtonLoadScene(string sceneName)
    {
        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        if (soundManager)
        {
            soundManager.PlayMenu(SoundManager.Menu.Press);
        }

        LoadScene(sceneName);
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName == "MainMenu")
        {
            if(GameObject.FindFirstObjectByType<GameManager>() != null)
                Destroy(GameObject.FindFirstObjectByType<GameManager>().gameObject);
            if (GameObject.FindFirstObjectByType<scoreSystem>() != null)
                Destroy(GameObject.FindFirstObjectByType<scoreSystem>().gameObject);
            if(GameObject.FindFirstObjectByType<LevelLoader>() != null)
                Destroy(GameObject.FindFirstObjectByType<LevelLoader>().gameObject);

            if (GameObject.Find("SoundManager"))
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayMusic(SoundManager.Music.MainMenu);
        }

        if (sceneName == "InGame")
        {
             if (GameObject.Find("SoundManager"))
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayMusic(SoundManager.Music.InGame);
        }

        if (sceneName == "ScoreMenu")
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayMusic(SoundManager.Music.ScoreMenu);
        }

        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (soundManager)
        {
            soundManager.PlayMenu(SoundManager.Menu.Press);
        }

        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>(); ;

        if (soundManager)
        {
            soundManager.PlayMenu(SoundManager.Menu.Press);
        }

        Application.Quit();
    }
}