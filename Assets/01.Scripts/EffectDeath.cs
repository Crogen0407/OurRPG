using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeath : MonoBehaviour
{
    [SerializeField] private float _duration = 1;
    [SerializeField] private GameObject _dieEffect;
    private void Awake()
    {
        StartCoroutine(EffectDeathCoroutine());
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
}
