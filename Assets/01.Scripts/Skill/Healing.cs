using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : Skill
{
    [SerializeField] private GameObject _skillEffect;
    
    //Managements
    private GameManager _gameManager;
    
    public override void Init()
    {
        _gameManager = GameManager.Instance;
        
        GameObject obj = Instantiate(_skillEffect, PlayerMovement.PlayerPosition, Quaternion.identity);
        obj.transform.parent = _gameManager.PlayerMovement.transform;
        EffectDeath effectDeath = obj.GetComponent<EffectDeath>();
        effectDeath.OnLastingEvent = () =>
        {
            _gameManager.PlayerHealthSystem.Hp+=level;
        };
        effectDeath.loopCount = 5;
        effectDeath.delayTime = 2;
        effectDeath.waitingTime = 0;
    }

    private IEnumerator HealingCoroutine(GameObject destroyGameObject)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2);
            _gameManager.PlayerHealthSystem.Hp+=level;
        }
        yield return new WaitForSeconds(delayTime);
        Destroy(destroyGameObject);        
    }
}
