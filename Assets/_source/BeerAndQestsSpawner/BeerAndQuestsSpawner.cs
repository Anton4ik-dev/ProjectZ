using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class BeerAndQuestsSpawner : MonoBehaviour
{
    private bool _isDrunk;
    [SerializeField] private Transform _alcoholSpawnPoints;
    [SerializeField] private List<Transform> _questTypes = new List<Transform>();
    [SerializeField] private AlcoholData alcSprites;

    void Start()
    {      
        QestPicker();
        Cursor.visible = false;
    }

    
    private void QestPicker()
    {
        int picker = 0;
        for (int i = 0; i < _questTypes.Count; i++)
        {
            picker = Random.Range(0, 5);
            _questTypes[i].GetChild(picker).gameObject.SetActive(true);
        }
        
    }

    private void AlcoholSpawner()
    {
        int amountOfPubs = Random.Range(1,11);
        for (int i = 0; i < amountOfPubs; i++)
        {
            int picker = Random.Range(0, 10);
            int alcImgRandom = Random.Range(0, 4);
            _alcoholSpawnPoints.GetChild(picker).GetComponent<SpriteRenderer>().sprite = alcSprites.aclImgs[alcImgRandom];
            _alcoholSpawnPoints.GetChild(picker).gameObject.SetActive(true);
        }
    }
    private void AlcoholDespawn()
    {
        for (int i = 0; i < 10; i++)
        {
            _alcoholSpawnPoints.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void GetBoolean(bool madMicelsonNaPricole)
    {
        _isDrunk = madMicelsonNaPricole;
        if (_isDrunk == true)
        {
            AlcoholSpawner();
        } else
        {
            AlcoholDespawn();
        }
    }
    
}
