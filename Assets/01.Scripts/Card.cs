using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Button _button; 
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _skillExplanationText;
    
    [SerializeField] private string _skillTitle;
    [TextArea]
    [SerializeField] private string _skillText;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(() =>
        {
            
        });

    }

    public void ChangeSkillTxt()
    {
        _titleText.text = _skillTitle;
        _skillExplanationText.text = _skillText;
    }
}
