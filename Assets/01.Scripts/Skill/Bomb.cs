using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Skill
{
    [SerializeField] private GameObject _bombGameObject;
    [SerializeField] private GameObject _skillEffect;
    
    public override void Init()
    {
        StartCoroutine(CreateBomb());
    }

    private IEnumerator CreateBomb()
    {
        GameObject obj = Instantiate(_bombGameObject, PlayerMovement.PlayerPosition, Quaternion.identity);

        yield return new WaitForSeconds(3);
        Instantiate(_skillEffect, obj.transform.position, Quaternion.identity);
        Destroy(obj);
    }
}
