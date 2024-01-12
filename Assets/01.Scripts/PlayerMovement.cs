using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private float _horizontal, _vertical;

    [SerializeField] private float _speed = 5;
    
    //Components
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(_horizontal, _vertical).normalized;
        _rigidbody.velocity = dir * _speed;
    }

    void Update()
    {
        
    }
}