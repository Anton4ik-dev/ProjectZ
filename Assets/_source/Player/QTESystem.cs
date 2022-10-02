using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private float _howMuchTimeLeft;
    private int _numberOFQte = 0;
    private int n = 1;
    private string rightCombo = "";
    private string input = "";
    private int id = 0;
    private int _valueFor;
    void Update()
    {
        if(n == 1)
        {
            TurnOff();
            for (int i = 0; i < _numberOFQte + 1; i++)
            {
                int num = Random.Range(0, 5);
                rightCombo += _alphabet[num];
                _variants[_numberOFQte].transform.GetChild(i).GetComponent<Image>().sprite = _sprites[num];
            }
            _variants[_numberOFQte].SetActive(true);
        }
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.E) && rightCombo[id] == 'E')
            {
                input += "E";
                id++;
            }
            else if (Input.GetKeyDown(KeyCode.R) && rightCombo[id] == 'R')
            {
                input += "R";
                id++;
            }
            else if (Input.GetKeyDown(KeyCode.T) && rightCombo[id] == 'T')
            {
                input += "T";
                id++;
            }
            else if (Input.GetKeyDown(KeyCode.G) && rightCombo[id] == 'G')
            {
                input += "G";
                id++;
            }
            else if (Input.GetKeyDown(KeyCode.V) && rightCombo[id] == 'V')
            {
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
            Debug.Log("Right");
            _variants[_numberOFQte].SetActive(false);
            TurnOn();
            _numberOFQte++;
            enabled = false;
            _timeLeft.maxValue = 5; 
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
        _gamePanel.gameObject.SetActive(false);
        _timeLeft.gameObject.SetActive(true);
    }

    private void TurnOn()
    {
        n = 1;
        _src1.enabled = true;
        _src2.enabled = true;
        _src3.enabled = true;
        _gamePanel.gameObject.SetActive(true);
        _timeLeft.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("ERROR");
        TurnOn();
        _variants[_numberOFQte].SetActive(false);
        enabled = false;
    }
}
