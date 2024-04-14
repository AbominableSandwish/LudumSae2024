using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject _canvasPausePrefab;
    GameObject _canvasPause;

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
            if (_canvasPause != null)
                Destroy(_canvasPause);
            if( GameObject.Find("GameManager"))
                Destroy(GameObject.Find("GameManager"));
            if (GameObject.Find("score"))
                Destroy(GameObject.Find("ScoreSystem"));

            if (GameObject.Find("SoundManager"))
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayMusic(SoundManager.Music.MainMenu);
        }

        if (sceneName == "InGame")
        {
            if (_canvasPausePrefab != null)
            {
                _canvasPause = Instantiate(_canvasPausePrefab);
                DontDestroyOnLoad(_canvasPause);
            }
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