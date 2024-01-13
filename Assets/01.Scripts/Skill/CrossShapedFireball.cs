using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossShapedFireball : Skill
{
    [SerializeField] private GameObject _skillEffect;
    [SerializeField] private float _speed = 8;
    
    public override void Init()
    {
        for (int i = 0; i < 3 + level; i++)
        {
            Debug.Log(level);
            GameObject obj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
            Vector2 skillDir = _speed * new Vector2(Mathf.Cos(Mathf.PI * 2 * i / (3 + level)),
                Mathf.Sin(Mathf.PI * 2 * i / (3 + level)));
            obj.transform.up = skillDir;
            obj.GetComponent<Rigidbody2D>().velocity = skillDir; 
        }
    }
}
