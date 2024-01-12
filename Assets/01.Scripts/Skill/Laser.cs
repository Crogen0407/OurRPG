using System.Collections;
using UnityEngine;

public class Laser : Skill
{
    [SerializeField] private GameObject _skillEffect;
    [SerializeField] private float _speed = 15;
    [SerializeField] private int _laserCount = 4;
    
    public override void Init()
    {
        StartCoroutine(ShootingLaser());
    }

    private IEnumerator ShootingLaser()
    {
        for (int i = 0; i < _laserCount; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject obj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
            obj.transform.up = PlayerAttackDirection.Direction;
            obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * _speed;
        }
    }
}
