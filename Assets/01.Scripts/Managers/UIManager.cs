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
            if (_isBaseEnable == true)
            {
                Tweening.Instance.DOMove(_baseTransform, new Vector3(0, 40, 0), 1, EasingType.EaseInSine);
            }
            else
            {
                Tweening.Instance.DOMove(_baseTransform, new Vector3(0, -612, 0), 1, EasingType.EaseInSine);
            }
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
