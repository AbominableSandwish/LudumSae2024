using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBubble : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;

    [SerializeField] List<Sprite> _complaints;

    public void SetComplaints(RequestSystem.resolution reso)
    {
        _renderer.sprite = _complaints[(int)reso];
    }
}
