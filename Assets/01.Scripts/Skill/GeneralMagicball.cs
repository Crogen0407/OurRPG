using System.Collections;
using UnityEngine;

public class GeneralMagicball : Skill
{
    [SerializeField] private GameObject _skillEffect;
    [SerializeField] private float _speed = 15;

    public override void Init()
    {
        GameObject obj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
        obj.transform.up = PlayerAttackDirection.Direction;
        obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * _speed;
    }
}
