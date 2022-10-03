using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSaver : MonoBehaviour
{
    public GameObject _text;
    public bool isNotTried = true;
    public bool isInteractable
    {
        get => isInteractable;

        set
        {
            if (isInteractable != value)
            {
                isInteractable = value;
            }
        }
    }
    public string questType;

}
