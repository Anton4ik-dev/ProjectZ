using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSaver : MonoBehaviour
{
    private static BeerAndQuestsSpawner _src;
    public GameObject _text;
    public bool isNotTried = true;
    private bool _isInteractable = true;
    private void Start()
    {
        _src = FindObjectOfType<BeerAndQuestsSpawner>();
    }
    public bool isInteractable
    {
        get => _isInteractable;

        set
        {
            if (_isInteractable != value)
            {
                _src.questDoneChecker(this);
                _isInteractable = value;
            }
        }
    }
    public string questType;

}
