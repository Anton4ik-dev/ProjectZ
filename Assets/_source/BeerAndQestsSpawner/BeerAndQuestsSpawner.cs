using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class BeerAndQuestsSpawner : MonoBehaviour
{
    private bool _isDrunk;
    public GameObject questFather;
    public GameObject beerFather;
    private int _kostl = 0;
    void Start()
    {
        if(_kostl == 0)
        {
            qestPicker();
            _kostl++;

        }
        
    }

    
    private void qestPicker()
    {
        int picker = Random.Range(0,5);
        questFather.transform.GetChild(picker).gameObject.SetActive(true);
    }

    private void alcoholSpawner()
    {
        int amountOfPubs = Random.Range(1,11);
        for (int i = 0; i < amountOfPubs; i++)
        {
            int picker = Random.Range(0, 10);
            beerFather.transform.GetChild(picker).gameObject.SetActive(true);
        }
    }
    private void alcoholDespawn()
    {
        for (int i = 0; i < 10; i++)
        {
            beerFather.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void assign(bool madMicelsonNaPricole)
    {
        _isDrunk = madMicelsonNaPricole;
        if (_isDrunk == true)
        {
            alcoholSpawner();
        } else
        {
            alcoholDespawn();
        }
    }
    
}
