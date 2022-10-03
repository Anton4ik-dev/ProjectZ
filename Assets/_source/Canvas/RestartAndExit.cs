using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartAndExit : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _back;
    [SerializeField] private GameObject _panel1;
    [SerializeField] private GameObject _panel2;
    [SerializeField] private AudioSource _but;
    private void Start()
    {
        _play.onClick.AddListener(Play);
        _settings.onClick.AddListener(Settings);
        _back.onClick.AddListener(Back);
    }
    private void Play()
    {
        _but.Play();
        SceneManager.LoadScene(1);
    }
    private void Settings()
    {
        _but.Play();
        _panel1.SetActive(false);
        _panel2.SetActive(true);
    }
    private void Back()
    {
        _but.Play();
        _panel1.SetActive(true);
        _panel2.SetActive(false);
    }
}
