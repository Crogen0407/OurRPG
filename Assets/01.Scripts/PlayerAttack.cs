using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<Skill> skills;
    private List<float> skillDelayTime;
    
    //Managements
    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = GameManager.Instance;
        
        //List
        skillDelayTime = new List<float>();
        int index = 0;
        foreach (var skill in skills)
        {
            skillDelayTime.Add(skill.delayTime);
            StartCoroutine(UseSkill(index));
            index++;
        }
    }

    private IEnumerator UseSkill(int skillIndex)
    {
        while (_gameManager.isGameOver == false)
        {
            skills[skillIndex].gameObject.SetActive(false);
            yield return new WaitForSeconds(skillDelayTime[skillIndex]);
            skills[skillIndex].gameObject.SetActive(true);
        }
    }
}