using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Button _button;
    private void Start()
    {
        _button.onClick.AddListener(Starter);
    }
    private void Update()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, -1f);
    }
    public void Starter()
    {
        Time.timeScale = 1;
        _button.transform.parent.gameObject.SetActive(false);
        _button.gameObject.SetActive(false);
        _player.GetComponent<PlayerMovement>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}