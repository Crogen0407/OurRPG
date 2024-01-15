using System;
using UnityEngine;

public class SceneDataManager : MonoSingleton<SceneDataManager>
{
    private int _storyLevel;

    //Managements
    private GameManager _gameManager;

    private void Awake()
    {
        //Managements
        _gameManager = GameManager.Instance;
    }

    public int StoryLevel
    {
        get => _storyLevel;
        set
        {
            if (_gameManager.SaveData.currentMaxStageIndex == StoryLevel)
            {
                _gameManager.SaveData = new SaveData()
                { 
                    currentMaxStageIndex = _gameManager.SaveData.currentMaxStageIndex + 1,
                    characterLevel = _gameManager.SaveData.characterLevel,
                    userName = _gameManager.SaveData.userName,
                    currentStoryIndex = _gameManager.SaveData.currentStoryIndex
                };
            }
            _storyLevel = value;
        }
    }
}
