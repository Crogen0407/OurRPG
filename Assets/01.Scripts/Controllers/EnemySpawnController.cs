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

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        else
        {
            CurrentTime = 0;
            _gameManager.GameClear = true;
        }
    }
    
    
}
