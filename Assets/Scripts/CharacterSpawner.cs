using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private SpriteRenderer _accessory;
    [SerializeField] private List<Sprite> _accessoriesList;
    [SerializeField] private SpriteRenderer _beak;
    [SerializeField] private List<Sprite> _beaksList;
    [SerializeField] private SpriteRenderer _eyes;
    [SerializeField] private List<Sprite> _eyesList;

    public void SpawnCharacter()
    {
        _body.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        _accessory.sprite = _accessoriesList[Random.Range(0, _accessoriesList.Count)];
        _beak.sprite = _beaksList[Random.Range(0, _beaksList.Count)];
        _eyes.sprite = _eyesList[Random.Range(0, _eyesList.Count)];
    }
    
}