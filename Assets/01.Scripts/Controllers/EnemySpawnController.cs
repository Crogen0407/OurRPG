using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnController : MonoBehaviour
{
    private float _maxTime = 300;
    private float _currentTime;
    public float CurrentTime
    {
        get => _currentTime;
        set
        {
            if ((int)_currentTime / 60 != (int)value / 60)
            {
                _spawnDelay--;
            }
            
            _currentTime = value;
            
            _timeText.text = $"{((int)_currentTime / 60).ToString("00")} : {((int)_currentTime % 60).ToString("00")}";
        }
    }

    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private Transform _enemySpawnTransform;
    [SerializeField ]private Transform[] _spawnPoints;

    [Space] [SerializeField] private string[] _enemyTypes;
    [SerializeField] private float _spawnDelay = 5;

    //Data
    private SO_StageData _stageData;
    public List<Enemy> currentEnemies;
    
    //Managements
    private GameManager _gameManager;
    private PoolManager _poolManager;
    
    private void Awake()
    {
        _spawnPoints = _enemySpawnTransform.GetComponentsInChildren<Transform>();
        _gameManager = GameManager.Instance;
        _poolManager = PoolManager.Instance;
     
        //Data
        _stageData = _gameManager.stageData;
        _maxTime = _stageData.survivalTimes[_stageData.currentStateIndex];
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
        int randomEnemy = Random.Range(0, _enemyTypes.Length);
        GameObject obj = _poolManager.Pop(_enemyTypes[randomEnemy], _spawnPoints[randomPos].position, Quaternion.identity);
        currentEnemies.Add(obj.GetComponent<Enemy>());
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
