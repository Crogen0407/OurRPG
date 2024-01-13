using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private float _maxTime = 300;
    private float _currentTime;
    public float CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = value;
            _timeText.text = $"{((int)_currentTime / 60).ToString("00")} : {((int)_currentTime % 60).ToString("00")}";
        }
    }

    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private Transform _enemySpawnTransform;
    
    //Managements
    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = GameManager.Instance;
        CurrentTime = _maxTime;
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MoveSpawnTransform();
    }

    void Update()
    {
        TimeChange();
    }

    private void MoveSpawnTransform()
    {
        Vector3 vec = new Vector3(_enemySpawnTransform.position.x, _enemySpawnTransform.position.y, 0);
        _enemySpawnTransform.position = vec;
    }

    private void TimeChange()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        else
        {
            CurrentTime = 0;
            _gameManager.timeClear = true;
        }
    }
    
}
