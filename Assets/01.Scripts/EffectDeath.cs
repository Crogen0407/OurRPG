using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeath : MonoBehaviour
{
    [SerializeField] private float _duration = 1;
    [SerializeField] private GameObject _dieEffect;
    public delegate void EnableEvent();
    public delegate void LastingEvent();

    public EnableEvent OnEnableEvent;
    public LastingEvent OnLastingEvent;
    public int waitingTime;
    public int delayTime;
    public int loopCount;
    
    private void Awake()
    {
        OnEnableEvent?.Invoke();
        StopAllCoroutines();
        StartCoroutine(EffectDeathCoroutine());
        StartCoroutine(OnLastingEventCoroutine());
    }

    private IEnumerator EffectDeathCoroutine()
    {
        yield return new WaitForSeconds(_duration);
        if (_dieEffect != null)
        {
            Instantiate(_dieEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private IEnumerator OnLastingEventCoroutine()
    {
        yield return new WaitForSeconds(waitingTime);
        for (int i = 0; i < loopCount; i++)
        {
            yield return new WaitForSeconds(delayTime);
            OnLastingEvent?.Invoke();
        }
        
    }
}
