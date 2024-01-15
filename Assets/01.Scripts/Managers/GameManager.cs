using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.BishojyoGraph.SlideEffect;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoSingletonOneScene<GameManager>
{
    private bool _gameClear;
    public bool GameClear
    {
        get => _gameClear;
        set
        {
            _gameClear = value;
            if (_gameClear == true)
            {
                SceneDataManager.Instance.StoryLevel++;
                
                GameScene_UIManager.Instance.ShowGameClearPanel();
            }
        }
    }

    public bool timeClear;
    
    private bool _gameOver;
    public bool GameOver
    {
        get => _gameOver;
        set
        {
            _gameOver = value;
            if (_gameOver == true)
            {
                GameScene_UIManager.Instance.ShowGameOverPanel();
                //SceneManager.LoadScene("StageChoiceScene");
            }
        }
    }
    
    //Data
    public SO_StageData stageData;
    private SaveData _saveData;

    public SaveData SaveData
    {
        get
        {
            try
            {
                _saveData = DataController.Load();
            }
            catch (NullReferenceException e)
            {
                DataController.Save(new SaveData());
                _saveData = DataController.Load();

            }
            return _saveData;
        }
        set
        {
            _saveData = value;
            DataController.Save(_saveData);
        }
    }
    
    //Controllers
    public DataController DataController { get; private set; }
    public EnemySpawnController EnemySpawnController { get; private set; }


    public PlayerMovement PlayerMovement { get; private set; }
    public HealthSystem PlayerHealthSystem { get; private set; }
    

    void Awake()
    {
        SetTimeScale(10);
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        PlayerHealthSystem = PlayerMovement.GetComponent<HealthSystem>();
        
        //Controllers
        DataController = FindObjectOfType<DataController>();
        EnemySpawnController = FindObjectOfType<EnemySpawnController>();

    }

    public void CheckGameClear()
    {
        if (EnemySpawnController.currentEnemies.Count <= 0 && timeClear == true)
        {
            StartCoroutine(CheckGameClearCoroutine());
        }
    }

    private IEnumerator CheckGameClearCoroutine()
    {
        yield return new WaitForSeconds(3);
        GameClear = true;
    }
    
    
    public void SetTimeScale(int value)
    {
        Time.timeScale = value;
    }
}
