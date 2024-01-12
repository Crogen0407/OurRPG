using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Button _button;
    [SerializeField] private TextMeshProUGUI _titleTxt;
    [SerializeField] private TextMeshProUGUI _skillTxt;
    
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
        _titleTxt.text = _skillTitle;
        _skillTxt.text = _skillText;
    }
}
