using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Sprite _standart;
    [SerializeField] private Sprite _drunker;
    private Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * _speed * Time.fixedDeltaTime);
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
        }
    }
}