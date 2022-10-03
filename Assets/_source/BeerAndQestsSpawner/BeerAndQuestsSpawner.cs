using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BeerAndQuestsSpawner : MonoBehaviour
{
    private bool _isDrunk;
    [SerializeField] private Transform _alcoholSpawnPoints;
    [SerializeField] private List<Transform> _questTypes = new List<Transform>();
    [SerializeField] private AlcoholData alcSprites;
    [SerializeField] private GameObject _hint;
    [SerializeField] private TMP_Text _hintText;
    [SerializeField] private GameObject _questUI;
    [SerializeField] private GameObject _alcoholUI;
    [SerializeField] private GameObject _alcStastsUI;
    [SerializeField] private List<string> _hints = new List<string>();
    [SerializeField] private List<Toggle> _checkBoxes = new List<Toggle>();

    private int _kostl = 0;


    

    void Start()
    {      
            
        QestPicker();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    private void QestPicker()
    {
        int picker = 0;
        for (int i = 0; i < _questTypes.Count; i++)
        {
            picker = Random.Range(0, _questTypes[i].childCount);
            _questTypes[i].GetChild(picker).gameObject.SetActive(true);
        }
        
    }

    private void AlcoholSpawner()
    {
        for (int i = 0; i < _alcoholSpawnPoints.childCount; i++)
        {
            int picker = Random.Range(0, _alcoholSpawnPoints.childCount);
            int alcImgRandom = Random.Range(0, 4);
            _alcoholSpawnPoints.GetChild(picker).GetComponent<SpriteRenderer>().sprite = alcSprites.aclImgs[alcImgRandom];
            _alcoholSpawnPoints.GetChild(picker).gameObject.SetActive(true);
        }
    }
    private void UiAlcMod()
    {   
        _alcStastsUI.gameObject.SetActive(true);
        _alcoholUI.SetActive(true);
        _questUI.SetActive(false);
    }
    private void UiQuestMod()
    {
        _alcStastsUI.gameObject.SetActive(false);
        _questUI.SetActive(true);
        _alcoholUI.SetActive(false);
        
    }
    private void AlcoholDespawn()
    {
        for (int i = 0; i < _alcoholSpawnPoints.childCount; i++)
        {
            _alcoholSpawnPoints.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void GetBoolean(bool madMicelsonNaPricole)
    {
        _isDrunk = madMicelsonNaPricole;
        if (_isDrunk == true)
        {
            for (int i = 0; i < _questTypes.Count; i++)
            {
                for (int j = 0; j < _questTypes[i].transform.childCount; j++)
                {
                    _questTypes[i].transform.GetChild(j).GetComponent<BoxCollider2D>().enabled = false;
                    _questTypes[i].transform.GetChild(j).GetChild(1).gameObject.SetActive(false);
                }
            }

           if(_kostl < 4)
            {
                Debug.Log(_kostl);
                _hintText.text = _hints[_kostl];
                _hint.gameObject.SetActive(true);
                _kostl++;
            }
            
            
            
            AlcoholSpawner();
            UiAlcMod();
        } else
        {
            for (int i = 0; i < _questTypes.Count; i++)
            {
                for (int j = 0; j < _questTypes[i].transform.childCount; j++)
                {
                    if(_questTypes[i].transform.GetChild(j).GetComponent<TextSaver>().isInteractable)
                    {
                        _questTypes[i].transform.GetChild(j).GetComponent<BoxCollider2D>().enabled = true;
                        _questTypes[i].transform.GetChild(j).GetChild(1).gameObject.SetActive(true);
                    }
                }
            }
            
            if (_kostl < 4)
            {
                Debug.Log(_kostl);
                _hintText.text = _hints[_kostl];
                _kostl++;
            }
            
            
            AlcoholDespawn();
            UiQuestMod();
        }
    }
    public void questDoneChecker()
    {
        for (int i = 0; i < _questTypes.Count; i++)
        {
            for (int j = 0; j < _questTypes[i].transform.childCount; j++)
            {
                if (_questTypes[i].transform.GetChild(j).GetComponent<TextSaver>().questType == "Rats")
                {
                    _checkBoxes[2].isOn = true;
                } else if (_questTypes[i].transform.GetChild(j).GetComponent<TextSaver>().questType == "Fontain")
                {
                    _checkBoxes[4].isOn = true;
                } else if (_questTypes[i].transform.GetChild(j).GetComponent<TextSaver>().questType == "OldMans")
                {
                    _checkBoxes[3].isOn = true;
                } else if (_questTypes[i].transform.GetChild(j).GetComponent<TextSaver>().questType == "Dogs")
                {
                    _checkBoxes[0].isOn = true;
                } else if (_questTypes[i].transform.GetChild(j).GetComponent<TextSaver>().questType == "Knockknock")
                {
                    _checkBoxes[1].isOn = true;
                }

            }
        }
    }
}
