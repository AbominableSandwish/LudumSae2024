using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIScore : MonoBehaviour
    {
        private const float TIME_TO_START = 1f;
        private static readonly int IsGain = Animator.StringToHash("isGain");

        [SerializeField] private TextMeshProUGUI _textScore;
        [SerializeField] private Button _btnBack;
        [SerializeField] private int _speed = 4;

        private Animator _animator;
        private int _score = 0;
        private int _current = 0;
        private float _counterTime = 0;
        //private ScoreSystem _scoreSystem;

        //private void Awake()
        //{
        //    _textScore.text = "0";
        //    _animator = _textScore.GetComponent<Animator>();


        //    _scoreSystem = FindAnyObjectByType<ScoreSystem>();
        //    if (_scoreSystem != null)
        //    {
        //        if (_scoreSystem.Score != 0)
        //        {
        //            _score = _scoreSystem.Score;
        //        }
        //    }

        //    Cursor.lockState = CursorLockMode.None;

        //    var soundManager = FindAnyObjectByType<SoundManager>();
        //    if (soundManager != null)
        //        soundManager.PlaySound(SoundManager.Sound.Lose);
        //}

        private void FixedUpdate()
        {
            _counterTime += Time.deltaTime;
            if (!(_counterTime > TIME_TO_START)) return;

            _animator.SetBool(IsGain, false);
            if (_current >= _score)
            {
                _btnBack.gameObject.SetActive(true);
                //if (_scoreSystem)
                //    _scoreSystem.ResetScore();

                return;
            }

            _animator.SetBool(IsGain, true);
            _current += _speed;
            _textScore.text = _current.ToString();
        }

        public void ButtonBack()
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().ButtonLoadScene("MainMenu");
        }
    };
}