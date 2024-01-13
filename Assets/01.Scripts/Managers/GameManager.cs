using System.Collections;
using System.Collections.Generic;
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
                SceneManager.LoadScene("StageChoiceScene");
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
                SceneManager.LoadScene("StageChoiceScene");
            }
        }
    }
    
    
    public PlayerMovement PlayerMovement { get; private set; }
    public HealthSystem PlayerHealthSystem { get; private set; }
    

    void Awake()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        PlayerHealthSystem = PlayerMovement.GetComponent<HealthSystem>();
    }
}
