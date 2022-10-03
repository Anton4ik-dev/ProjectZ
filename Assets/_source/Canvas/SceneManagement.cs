using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _back;
    [SerializeField] private Button _exit;
    [SerializeField] private GameObject _panel1;
    [SerializeField] private GameObject _panel2;
    private void Start()
    {
        _play.onClick.AddListener(Play);
        _exit.onClick.AddListener(Exit);
        _settings.onClick.AddListener(Settings);
        _back.onClick.AddListener(Back);
    }
    private void Play()
    {
        SceneManager.LoadScene(1);
    }
    private void Exit()
    {
        Application.Quit();
    }
    private void Settings()
    {
        _panel1.SetActive(false);
        _panel2.SetActive(true);
    }
    private void Back()
    {
        _panel1.SetActive(true);
        _panel2.SetActive(false);
    }
}
