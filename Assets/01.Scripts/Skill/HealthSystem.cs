using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    public delegate void DieEvent();
    public delegate void HpUpEvent();
    public delegate void HpDownEvent();
    
    public DieEvent OnDieEvent;
    public HpUpEvent OnHpUpEvent;
    public HpDownEvent OnHpDownEvent;
    
    [SerializeField] private float _hp = 100;

    public float Hp
    {
        get => _hp;
        set
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
