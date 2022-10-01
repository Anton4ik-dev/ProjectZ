using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _neededPromile;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Sprite _standart;
    [SerializeField] private Sprite _drunker;
    [SerializeField] private AlcoholData _alcoholData;
    private Vector2 movement;
    private float _promile;
    private bool _isInteractable = false;
    private Collider2D _collision;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("Speed", movement.sqrMagnitude);

        if(_isInteractable)
        {
            if(Input.GetButtonDown("Jump"))
            {
                if (_collision.gameObject.layer == 3)
                {
                    _collision.gameObject.SetActive(false);
                }
                if (_collision.gameObject.layer == 6)
                {
                    _collision.gameObject.SetActive(false);
                    ChangePromile(_collision.tag);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collision = collision;
        _isInteractable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isInteractable = false;
    }

    private void ChangePromile(string drink)
    {
        if(drink == "wine")
        {
            _promile += _alcoholData.winePromile;
        } else if(drink == "whisky")
        {
            _promile += _alcoholData.whiskyPromile;
        }
        else if (drink == "beer")
        {
            _promile += _alcoholData.beerPromile;
        }
        else if (drink == "vodka")
        {
            _promile += _alcoholData.vodkaPromile;
        }
    }

    public void ChangePlayerMod(bool mod)
    {
        //_animator.SetBool("Mod", mod);
        if(mod)
        {
            _playerSprite.sprite = _drunker;
        } else
        {
            _playerSprite.sprite = _standart;
            if(_promile <= _neededPromile)
            {
                Debug.Log("Not enough alcohol");
                _promile = 0;
            } 
        }
    }
}