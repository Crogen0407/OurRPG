using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    public delegate void DieEvent();
    public delegate void HpUpEvent();
    public delegate void HpDownEvent();
    public delegate void HpChangeEvent();
    
    public DieEvent OnDieEvent;
    public HpUpEvent OnHpUpEvent;
    public HpDownEvent OnHpDownEvent;
    public HpChangeEvent OnHpChangeEvent;
    
    
    [SerializeField] private float _hp = 100;
    public float MaxHp { get; private set; }

    private void OnEnable()
    {
        MaxHp = _hp;
    }


    public float Hp
    {
        get => _hp;
        set
        {
            OnHpChangeEvent?.Invoke();
            if (gameObject.activeSelf == true)
            {
                if (_hp > value)
                {
                    OnHpDownEvent?.Invoke();
                }
                else if(_hp < value)
                {
                    OnHpUpEvent?.Invoke();
                }
            
                _hp = value;
                if (_hp <= 0.05f)
                {
                    _hp = 0;
                    OnDieEvent?.Invoke();
                }                
            }
        }
    }
}
