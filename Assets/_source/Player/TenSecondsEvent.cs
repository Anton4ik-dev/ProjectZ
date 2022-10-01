using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenSecondsEvent : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMethod;
    private bool _isDrunkerMod = false;
    private float _tenSeconds = 10f;
    public bool IsDrunkerMod
    {
        get => _isDrunkerMod;
        set
        {
            if(_isDrunkerMod != value)
            {
                _isDrunkerMod = value;
                //call methods
                _playerMethod.ChangePlayerMod(IsDrunkerMod);
            }
        }
    }

    private void Update()
    {
        _tenSeconds -= Time.deltaTime;
        if(_tenSeconds <= 0)
        {
            IsDrunkerMod = !_isDrunkerMod;
            _tenSeconds = 10f;
        }
    }
}