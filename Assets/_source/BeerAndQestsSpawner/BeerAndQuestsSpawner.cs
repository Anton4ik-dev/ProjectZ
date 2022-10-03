using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeerAndQuestsSpawner : MonoBehaviour
{
    private bool _isDrunk;
    [SerializeField] private Transform _alcoholSpawnPoints;
    [SerializeField] private List<Transform> _questTypes = new List<Transform>();
    [SerializeField] private AlcoholData alcSprites;
    [SerializeField] private GameObject _hint;
    [SerializeField] private GameObject _questUI;
    [SerializeField] private GameObject _alcoholUI;
    [SerializeField] private GameObject _alcStastsUI;

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
            if (_kostl == 0)
            {
                _hint.gameObject.SetActive(true);
            }
            AlcoholSpawner();
            //UiAlcMod();
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
            _hint.gameObject.SetActive(false);
            _kostl++;
            AlcoholDespawn();
            //UiQuestMod();
        }
    }
    
}
