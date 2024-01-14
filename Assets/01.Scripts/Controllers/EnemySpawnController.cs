using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

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
            if ((int)_currentTime % 60 == 0)
            {
                _spawnDelay--;
            }
            _timeText.text = $"{((int)_currentTime / 60).ToString("00")} : {((int)_currentTime % 60).ToString("00")}";
        }
    }

    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private Transform _enemySpawnTransform;
    [SerializeField ]private Transform[] _spawnPoints;

    [Space] [SerializeField] private string[] _enemies;
    [SerializeField] private float _spawnDelay = 5;

    //Managements
    private GameManager _gameManager;
    private PoolManager _poolManager;
    
    private void Awake()
    {
        _spawnPoints = _enemySpawnTransform.GetComponentsInChildren<Transform>();
        _gameManager = GameManager.Instance;
        _poolManager = PoolManager.Instance;
        
        CurrentTime = _maxTime;
        _spawnDelay = ((int)_maxTime / 60) + 1;
    }

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
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

    private void SpawnEnemy()
    {
        int randomPos = Random.Range(1, _spawnPoints.Length);
        int randomEnemy = Random.Range(0, _enemies.Length);
        _poolManager.Pop(_enemies[randomEnemy], _spawnPoints[randomPos].position, Quaternion.identity);
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

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (_gameManager.timeClear == false)
        {
            yield return new WaitForSeconds(_spawnDelay);
            SpawnEnemy();
        }
    }
}
