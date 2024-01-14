using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private float _horizontal, _vertical;

    [SerializeField] private float _speed = 5;

    public static Vector3 PlayerPosition { get; private set; }

    //Components
    private Rigidbody2D _rigidbody;
    
    //Managements
    private GameManager _gameManager;
    
    void Awake()
    {
        //Components
        _rigidbody = GetComponent<Rigidbody2D>();
        
        //Managements
        _gameManager = GameManager.Instance;
    }

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(_horizontal, _vertical).normalized;
        if ((_gameManager.GameOver || _gameManager.GameClear || _gameManager.timeClear) == false)
        {
            _rigidbody.velocity = dir * _speed;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }

    }

    void Update()
    {
        PlayerPosition = transform.position;
    }
}