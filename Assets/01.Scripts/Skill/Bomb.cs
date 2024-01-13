using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Skill
{
    [SerializeField] private GameObject _bombGameObject;
    
    public override void Init()
    {
        GameObject obj = Instantiate(_bombGameObject, PlayerMovement.PlayerPosition, Quaternion.identity);
    }
}
