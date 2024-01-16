using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene_UIManager : MonoSingletonOneScene<GameScene_UIManager>
{
    [SerializeField] private RectTransform _gameResultPanel;
    [SerializeField] private RectTransform _powerUpPanel;
    [SerializeField] private GameObject _levelUpCardPrefab;
    [SerializeField] private RectTransform _hpBar;
    
    
    private Transform _cardGroup;
    private TextMeshProUGUI _gameResultText;

    //Components
    private PlayerAttack _playerAttack;
    
    //Managements
    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameResultText = _gameResultPanel.Find("txt_title").GetComponent<TextMeshProUGUI>();
        
        //Managements
        _gameManager = GameManager.Instance;
        _playerAttack = _gameManager.PlayerAttack;
    }

    public void SetHpBarValue(float value)
    {
        _hpBar.localScale = new Vector3(value, 1, 1);
    }
    
    public void EnableSettingPanel()
    {
        
    }
    
    public void ShowGameOverPanel()
    {
        Tweening.Instance.DOMove(_gameResultPanel, Vector2.zero, 0.5f, EasingType.EaseOutSine, lateAction: () =>
        {
            _gameManager.SetTimeScale(0);
        });
        _gameResultText.text = "죽었네요";
    }

    public void ShowGameClearPanel()
    {
        Tweening.Instance.DOMove(_gameResultPanel, Vector2.zero, 0.5f, EasingType.EaseOutSine);
        _gameResultText.text = "견뎌냈네요";
    }

    public void SceneLoad(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ShowPowerUpPanel()
    {
        _powerUpPanel.gameObject.SetActive(true);
        
        if (_cardGroup == null)
            _cardGroup = _powerUpPanel.Find("CardGroup");

        for (int i = 0; i < 3; i++)
        {
            Skill skill = _playerAttack.GetRandomLevelUpSkill();
            GameObject obj = Instantiate(_levelUpCardPrefab, _cardGroup);
            obj.transform.Find("txt_title").GetComponent<TextMeshProUGUI>().text = skill.skillInfo.name;
            obj.transform.Find("box_profileImage").GetComponent<Image>().sprite = skill.skillInfo.icon;
            obj.transform.Find("txt_skillExplanation").GetComponent<TextMeshProUGUI>().text = skill.skillInfo.text;
        }
        
        GameManager.Instance.SetTimeScale(0);
    }

    public void ResetScale(RectTransform rectTransform)
    {
        rectTransform.localScale = Vector3.one;
    }
}
