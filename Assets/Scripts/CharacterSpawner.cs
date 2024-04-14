using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private SpriteRenderer _scratchMarks;
    [SerializeField] private SpriteRenderer _accessory;
    [SerializeField] private SpriteRenderer _accessory2;
    [SerializeField] private List<Sprite> _accessoriesList;
    [SerializeField] private SpriteRenderer _beak;
    [SerializeField] private List<Sprite> _beaksList;
    [SerializeField] private SpriteRenderer _eyes;
    [SerializeField] private List<Sprite> _eyesList;
    [SerializeField] private List<Sprite> _sadEyesList;
    [SerializeField] private Sprite _happyEyes;

    public SpriteRenderer ScratchMarks => _scratchMarks;
    public SpriteRenderer Eyes => _eyes;
    public List<Sprite> SadEyesList => _sadEyesList;
    public Sprite HappyEyes => _happyEyes;

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
}
