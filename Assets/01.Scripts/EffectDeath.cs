using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeath : MonoBehaviour
{
    [SerializeField] private float _duration = 1;
    private void Awake()
    {
        StartCoroutine(EffectDeathCoroutine());
    }

    private IEnumerator EffectDeathCoroutine()
    {
        yield return new WaitForSeconds(_duration);
        Destroy(gameObject);
    }
}
