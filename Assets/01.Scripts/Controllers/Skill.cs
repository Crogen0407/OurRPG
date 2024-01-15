using System;
using UnityEngine;

public delegate void OnEnableSkill();

public abstract class Skill : MonoBehaviour
{
    public int level;
    public float delayTime = 0.1f;
    public SkillInfo skillInfo;
    
    public OnEnableSkill OnEnableSkill;
    
    public abstract void Init();
    
    private void OnEnable()
    {
        Init();
        OnEnableSkill?.Invoke();
    }
    
    public float EaseInCirc(float x)
    {
        return 1 - Mathf.Sqrt(1f - Mathf.Pow(x, 2));
    }
}


[Serializable]
public struct SkillInfo
{
    public string name;
    public Sprite icon;
    [TextArea]
    public string text;
}
