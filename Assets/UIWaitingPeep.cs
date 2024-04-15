using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWaitingPeep : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    RequestSystem _requestSystem;
    private void Start()
    {
        _requestSystem = GameObject.FindFirstObjectByType<RequestSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_requestSystem)
        {
            _text.text = _requestSystem.NbrRequest.ToString();
        }
    }
}
