using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSwordAttack : Skill
{
    [SerializeField] private GameObject _skillEffect;
    public override void Init()
    {
        OnEnableSkill = () =>
        {
           GameObject obj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
           obj.transform.up = -PlayerAttackDirection.Direction;
        };
    }
}
