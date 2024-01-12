using System;
using UnityEngine;

public delegate void OnEnableSkill();

public abstract class Skill : MonoBehaviour
{
    public string type;
    public int level;
    public float delayTime = 0.1f;

    public OnEnableSkill OnEnableSkill;

    public abstract void Init();
    
    private void OnEnable()
    {
        Init();
        OnEnableSkill?.Invoke();
    }
}
