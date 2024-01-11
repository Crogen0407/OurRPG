using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    //Components
    private CinemachineConfiner2D _cinemachineConfiner2D;

    private bool _drag = false;
    private Vector3 _difference;
    private Vector3 _origin;
    
    void Awake()
    {
        //Components
        _cinemachineConfiner2D = GetComponent<CinemachineConfiner2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if (_drag == false)
            {
                _drag = true;
                _origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            _drag = false;
        }

        if (_drag == true)
        {
            transform.position = _origin - _difference;
        }
    }
}
