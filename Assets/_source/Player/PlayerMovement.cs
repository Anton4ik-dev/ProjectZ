using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _neededPromile;
    [SerializeField] private Rigidbody2D _rb;
    public Animator _animator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Sprite _standart;
    [SerializeField] private Sprite _drunker;
    [SerializeField] private AlcoholData _alcoholData;
    [SerializeField] private QTESystem _qteSys;
    [SerializeField] private TMP_Text _promileLvl;
    private Vector2 movement;
    private float _promile;
    private bool _isInteractable = false;
    public Collider2D collision;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("Speed", movement.sqrMagnitude);

        if(_isInteractable)
        {
            if (collision.gameObject.layer == 6) //alcohol
            {
                collision.gameObject.SetActive(false);
                ChangePromile(collision.GetComponent<SpriteRenderer>().sprite.name);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (collision.gameObject.layer == 3) //events
                {
                    _qteSys.enabled = true;
                }
                
            }
        }
        _promileLvl.text = _promile + "/100";
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.collision = collision;
        if(this.collision.gameObject.layer == 3)
            this.collision.transform.GetChild(0).gameObject.SetActive(true);
        _isInteractable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(this.collision.gameObject.layer == 3)
            this.collision.transform.GetChild(0).gameObject.SetActive(false);
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
            Debug.Log(_promile);
            if(_promile <= _neededPromile)
            {
                SceneManager.LoadScene(0);
                _promile = 0;
            } 
        }
    }
}