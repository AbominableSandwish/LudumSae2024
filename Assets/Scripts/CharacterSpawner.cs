using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private SpriteRenderer _accessory;
    [SerializeField] private SpriteRenderer _accessory2;
    [SerializeField] private List<Sprite> _accessoriesList;
    [SerializeField] private SpriteRenderer _beak;
    [SerializeField] private List<Sprite> _beaksList;
    [SerializeField] private SpriteRenderer _eyes;
    [SerializeField] private List<Sprite> _eyesList;
    [SerializeField] private List<Sprite> _sadEyesList;
    [SerializeField] private Sprite _happyEyes;
    
    public SpriteRenderer Eyes => _eyes;
    public List<Sprite> SadEyesList => _sadEyesList;
    public Sprite HappyEyes => _happyEyes;
    
    [SerializeField] private SpriteRenderer _spellResult1;
    [SerializeField] private SpriteRenderer _spellResult2;
    [SerializeField] private Sprite _defaultFailure;
    [SerializeField] private Sprite _healFailure;
    [SerializeField] private Sprite _invisibilityFailure1;
    [SerializeField] private Sprite _invisibilityFailure2;
    [SerializeField] private Sprite _metamorphosisFailure;
    [SerializeField] private Sprite _metamorphosisSuccess1;
    [SerializeField] private Sprite _metamorphosisSuccess2;

    SoundManager _soundManager;

    private void Start()
    {
        _soundManager = FindFirstObjectByType<SoundManager>();
    }

    public SpriteRenderer SpellResult1 => _spellResult1;

    public void SpawnCharacter()
    {
        _body.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        _accessory.sprite = _accessoriesList[Random.Range(0, _accessoriesList.Count)];
        _accessory2.sprite = _accessoriesList[Random.Range(0, _accessoriesList.Count)];
        _beak.sprite = _beaksList[Random.Range(0, _beaksList.Count)];
        _eyes.sprite = _eyesList[Random.Range(0, _eyesList.Count)];
    }
    

    public void Talk()
    {
        GameObject.Find("SpeechBubble").GetComponent<Animator>().Play("SpeechBubble");
    }


    public void Exit()
    {
        GameObject.Find("SpeechBubble").GetComponent<Animator>().Play("SpeechBubbleReverse");
    }
    
    public void SetSpellResult(RequestSystem.resolution resolution, bool rightSpell)
    {
        switch (rightSpell)
        {
            case true:
                //"Success" cases: Right spell
                switch (resolution)
                {
                    case RequestSystem.resolution.metamorphosis:
                        if (_spellResult1)
                            _spellResult1.sprite = _metamorphosisSuccess1;
                        if (_spellResult2)
                            _spellResult2.sprite = _metamorphosisSuccess2;
                        break;
                    case RequestSystem.resolution.Hurt:
                        if (_spellResult1)
                            _spellResult1.sprite = null;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                    case RequestSystem.resolution.Invisible:
                        if (_soundManager)
                        {
                            _soundManager.PlaySound(SoundManager.Sound.SuccesStealth);
                        }
                        if (_spellResult1)
                            _spellResult1.sprite = null;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        _body.sprite = null;
                        _beak.sprite = null;
                        _eyes.sprite = null;
                        break;
                    case RequestSystem.resolution.Lens:
                        if (_spellResult1)
                            _spellResult1.sprite = null;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                    case RequestSystem.resolution.Tongue:
                        if (_spellResult1)
                            _spellResult1.sprite = null;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                    case RequestSystem.resolution.Pickle:
                        if (_soundManager)
                        {
                            _soundManager.PlaySound(SoundManager.Sound.OpenPickle);
                        }
                        if(_spellResult1)
                            _spellResult1.sprite = null;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                }

                break;
            case false: 
                //"Failure" cases: Wrong spell
                switch (resolution)
                {
                    case RequestSystem.resolution.metamorphosis:
                        if (_soundManager)
                        {
                            _soundManager.PlaySound(SoundManager.Sound.Demon);
                        }
                        if (_spellResult1)
                            _spellResult1.sprite = _metamorphosisFailure;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                    case RequestSystem.resolution.Hurt:
                        if (_soundManager)
                        {
                            _soundManager.PlaySound(SoundManager.Sound.Burning);
                        }
                        if (_spellResult1)
                            _spellResult1.sprite = _defaultFailure;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                    case RequestSystem.resolution.Invisible:
                        if (_soundManager)
                        {
                            _soundManager.PlaySound(SoundManager.Sound.FailureStealth);
                        }
                        if (_spellResult1)
                            _spellResult1.sprite = _invisibilityFailure1;
                        if (_spellResult2)
                            _spellResult2.sprite = _invisibilityFailure2;
                        break;
                    case RequestSystem.resolution.Lens:
                        if(_spellResult1)
                            _spellResult1.sprite = _defaultFailure;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                    case RequestSystem.resolution.Tongue:
                        if (_spellResult1)
                            _spellResult1.sprite = _defaultFailure;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                    case RequestSystem.resolution.Pickle:
                        if (_spellResult1)
                            _spellResult1.sprite = _defaultFailure;
                        if (_spellResult2)
                            _spellResult2.sprite = null;
                        break;
                }
                break;
        }
    }
}