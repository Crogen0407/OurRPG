using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Skill
{
    [SerializeField] private GameObject _bombGameObject;
    
    public override void Init()
    {
        for (int i = 0; i < level; i++)
        {
            Vector3 randomVec = new Vector2(Random.Range(-2, 2f), Random.Range(-2, 2f));
            GameObject obj = Instantiate(_bombGameObject, PlayerMovement.PlayerPosition + randomVec, Quaternion.identity);
        }
    }
}
