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
    
    void Awake()
    {
        //Components
        _rigidbody = GetComponent<Rigidbody2D>();
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
        PlayerPosition = transform.position;
    }
}