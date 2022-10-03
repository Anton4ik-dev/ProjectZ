using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit;
    private void Start()
    {
        _play.onClick.AddListener(Play);
        _exit.onClick.AddListener(Exit);
    }
    private void Play()
    {
        SceneManager.LoadScene(1);
    }
    private void Exit()
    {
        Application.Quit();
    }
}
