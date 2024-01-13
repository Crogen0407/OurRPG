using System.Collections;
using UnityEngine;

public class Laser : Skill
{
    [SerializeField] private GameObject _skillEffect;
    [SerializeField] private float _speed = 15;
    
    public override void Init()
    {
        GameObject firstObj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
        firstObj.transform.up = (PlayerAttackDirection.Direction);
        firstObj.GetComponent<Rigidbody2D>().velocity = firstObj.transform.up * _speed;

        for (int i = 0; i < level -1 ; i++)
        {
            Debug.Log("발사");
            GameObject obj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
            Vector2 randomVec = new Vector2(Random.Range(-2, 2f), Random.Range(-2, 2f));
            obj.transform.up = (PlayerAttackDirection.Direction + randomVec).normalized;
            obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * _speed;
        }    
    }
}
