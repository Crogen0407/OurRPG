using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossShapedFireball : Skill
{
    [SerializeField] private GameObject _skillEffect;
    [SerializeField] private float _speed = 8;
    [SerializeField] private int _fireballCount = 4;
    
    public override void Init()
    {
        for (int i = 0; i < _fireballCount; i++)
        {
            GameObject obj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
            Vector2 skillDir = _speed * new Vector2(Mathf.Cos(Mathf.PI * 2 * i / _fireballCount),
                Mathf.Sin(Mathf.PI * 2 * i / _fireballCount));
            obj.transform.up = skillDir;
            obj.GetComponent<Rigidbody2D>().velocity = skillDir; 
        }
    }
}
