using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    private void Start()
    {
        _play.onClick.AddListener(Play);
    }
    private void Play()
    {
        SceneManager.LoadScene(1);
    }
}
