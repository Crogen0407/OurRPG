using System;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(() =>
        {
            
        });
    }
    
    
}
