using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{
    [Space]
    [SerializeField] private List<string> _alphabet = new List<string>();
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();
    [SerializeField] private List<GameObject> _variants = new List<GameObject>();
    [SerializeField] private BeerAndQuestsSpawner _src1;
    [SerializeField] private TenSecondsEvent _src2;
    [SerializeField] private PlayerMovement _src3;
    [SerializeField] private Transform _gamePanel;
    [SerializeField] private Slider _timeLeft;
    [SerializeField] private AudioSources _audio;
    [SerializeField] private GameObject _winPanel;
    private int _numberOFQte = 0;
    private int n = 1;
    private string rightCombo = "";
    private string input = "";
    private int id = 0;
    private int _valueFor = 5;
    

    void Update()
    {
            if (n == 1)
            {
            _audio._main.Pause();
                TurnOff();
                for (int i = 0; i < _numberOFQte + 1; i++)
                {
                    int num = Random.Range(0, 5);
                    rightCombo += _alphabet[num];
                    _variants[_numberOFQte].transform.GetChild(i).GetComponent<Image>().sprite = _sprites[num];
                }
                _variants[_numberOFQte].SetActive(true);
                _src3.collision.GetComponent<TextSaver>()._text.SetActive(true);
            }
            if (Input.anyKeyDown)
            {
            _audio._buttonSound.Play();
                if (Input.GetKeyDown(KeyCode.E) && rightCombo[id] == 'E')
                {
                _variants[_numberOFQte].transform.GetChild(id).GetComponent<Image>().color = Color.green;
                input += "E";
                    id++;
                }
                else if (Input.GetKeyDown(KeyCode.R) && rightCombo[id] == 'R')
                {
                _variants[_numberOFQte].transform.GetChild(id).GetComponent<Image>().color = Color.green;
                input += "R";
                    id++;
                }
                else if (Input.GetKeyDown(KeyCode.T) && rightCombo[id] == 'T')
                {
                _variants[_numberOFQte].transform.GetChild(id).GetComponent<Image>().color = Color.green;
                input += "T";
                    id++;
                }
                else if (Input.GetKeyDown(KeyCode.G) && rightCombo[id] == 'G')
                {
                _variants[_numberOFQte].transform.GetChild(id).GetComponent<Image>().color = Color.green;
                input += "G";
                    id++;
                }
                else if (Input.GetKeyDown(KeyCode.V) && rightCombo[id] == 'V')
                {
                _variants[_numberOFQte].transform.GetChild(id).GetComponent<Image>().color = Color.green;
                input += "V";
                    id++;
                }
                else
                {
                    Exit();
                }
            }
            if (rightCombo == input)
            {
            _audio._main.UnPause();
            if (_src3.collision.transform.GetComponent<TextSaver>().questType == "Rats")
            {
                _audio._mouse.Play();
            }
            else if (_src3.collision.transform.GetComponent<TextSaver>().questType == "Fontain")
            {
                _audio._water.Play();
            }
            else if (_src3.collision.transform.GetComponent<TextSaver>().questType == "OldMans")
            {
                _audio._oldMan.Play();
            }
            else if (_src3.collision.transform.GetComponent<TextSaver>().questType == "Dogs")
            {
                _audio._bark.Play();
            }
            else if (_src3.collision.transform.GetComponent<TextSaver>().questType == "Knockknock")
            {
                _audio._knock.Play();
            }
            _variants[_numberOFQte].SetActive(false);
            TurnOn();
            _src3.collision.GetComponent<BoxCollider2D>().enabled = false;
            _src3.collision.transform.GetComponent<TextSaver>().isInteractable = false;
            _src3.collision.transform.GetChild(1).gameObject.SetActive(false);
            _numberOFQte++;
            enabled = false;
            _valueFor = 4;
            _timeLeft.maxValue = _valueFor;
            if (_numberOFQte == 5)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                _audio._main.Pause();
                Invoke("LateTurnOn", 10);
                
                _winPanel.SetActive(true);
            }
            }
            _timeLeft.value -= Time.deltaTime;
            if (_timeLeft.value <= 0)
            {
                Exit();
            }
        
    }
    private void TurnOff()
    {
        rightCombo = "";
        input = "";
        id = 0;
        n = 0;
        _src1.enabled = false;
        _src2.enabled = false;
        _src3.enabled = false;
        _src3._animator.enabled = false;
        _gamePanel.gameObject.SetActive(false);
        _src3.collision.transform.GetChild(0).gameObject.SetActive(false);
        _timeLeft.gameObject.SetActive(true);
    }

    private void TurnOn()
    {
        _src3.collision.GetComponent<TextSaver>()._text.SetActive(false);
        n = 1;
        _src1.enabled = true;
        _src2.enabled = true;
        _src3.enabled = true;
        _src3._animator.enabled = true;
        _gamePanel.gameObject.SetActive(true);
        _timeLeft.gameObject.SetActive(false);
        _timeLeft.value = _valueFor;
    }

    public void Exit()
    {
        _audio._main.UnPause();
        _src3.collision.GetComponent<BoxCollider2D>().enabled = false;
        _src3.collision.transform.GetChild(1).gameObject.SetActive(false);
        _src3.collision.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < _variants[_numberOFQte].transform.childCount; i++)
        {
            _variants[_numberOFQte].transform.GetChild(i).GetComponent<Animator>().enabled = true;
        }
        Invoke("Caller", 1.5f);
        enabled = false;
    }
    public void Caller()
    {
        TurnOn();
        _variants[_numberOFQte].SetActive(false);
        for (int i = 0; i < _variants[_numberOFQte].transform.childCount; i++)
        {
            _variants[_numberOFQte].transform.GetChild(i).GetComponent<Animator>().enabled = false;
            _variants[_numberOFQte].transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }
    }

    private void LateTurnOn()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }
}
