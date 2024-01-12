using System.Collections;
using System.Collections.Generic;
using Crogen.Tweening;
using UnityEngine;

public class UIManager : MonoSingletonOneScene<UIManager>
{
    [SerializeField] private RectTransform _baseTransform;
    private bool _isBaseEnable;

    public bool IsBaseEnable
    {
        get => _isBaseEnable;
        set
        {
            _isBaseEnable = value;
            float posY = 0;
            if (_isBaseEnable == true)
            {
                posY = 40;
            }
            else
            {
                posY = -612;
            }
            Tweening.Instance.DOMove(_baseTransform, new Vector3(0, posY, 0), 0.5f, EasingType.EaseInOutSine);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            IsBaseEnable = !IsBaseEnable;
        }
    }
}
