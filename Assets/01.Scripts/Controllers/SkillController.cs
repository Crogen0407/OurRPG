using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.BishojyoGraph;
using Unity.VisualScripting;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public Queue<SO_SkillData> skills;

    private void Awake()
    {
        skills = new Queue<SO_SkillData>();
    }

    public void AddSkillQueue(SO_SkillData skillData)
    {
        skills.Enqueue(skillData);
    }
}