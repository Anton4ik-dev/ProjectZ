using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private QTESystem _qteSys;
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
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (_collision.gameObject.layer == 3) //events
                {
                    _qteSys.enabled = true;
                }
                if (_collision.gameObject.layer == 6) //alcohol
                {
                    _collision.gameObject.SetActive(false);
                    ChangePromile(_collision.GetComponent<SpriteRenderer>().sprite.name);
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
        if(_collision.gameObject.layer == 3)
            _collision.transform.GetChild(0).gameObject.SetActive(true);
        _isInteractable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_collision.gameObject.layer == 3)
            _collision.transform.GetChild(0).gameObject.SetActive(false);
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
        _animator.SetBool("Mod", mod);
        if(mod)
        {
            _playerSprite.sprite = _drunker;
        } else
        {
            _playerSprite.sprite = _standart;
            if(_promile <= _neededPromile)
            {
                //lose
                _promile = 0;
            } 
        }
    }
}