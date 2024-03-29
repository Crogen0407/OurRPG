using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        while ((_gameManager.GameOver || _gameManager.GameClear) == false)
        {
            skills[skillIndex].gameObject.SetActive(false);
            yield return new WaitForSeconds(skillDelayTime[skillIndex]);
            if (skills[skillIndex].level > 0)
            {
                skills[skillIndex].gameObject.SetActive(true);
            }
        }
    }

    public Skill GetRandomLevelUpSkill()
    {
        return skills[Random.Range(0, skills.Count)];
    }
}