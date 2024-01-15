using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene_UIManager : MonoSingletonOneScene<GameScene_UIManager>
{
    [SerializeField] private RectTransform _gameResultPanel;
    private TextMeshProUGUI _gameResultText;

    private void Awake()
    {
        _gameResultText = _gameResultPanel.Find("txt_title").GetComponent<TextMeshProUGUI>();
    }

    public void EnableSettingPanel()
    {
        
    }
    
    public void ShowGameOverPanel()
    {
        Tweening.Instance.DOMove(_gameResultPanel, Vector2.zero, 1.5f, EasingType.EaseOutElastic, lateAction: () =>
        {
            GameManager.Instance.SetTimeScale(0);
        });
        _gameResultText.text = "죽었네요";
    }

    public void ShowGameClearPanel()
    {
        Tweening.Instance.DOMove(_gameResultPanel, Vector2.zero, 1.5f, EasingType.EaseOutElastic);
        _gameResultText.text = "견뎌냈네요";
    }

    public void SceneLoad(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ResetScale(RectTransform rectTransform)
    {
        rectTransform.localScale = Vector3.one;
    }
}
