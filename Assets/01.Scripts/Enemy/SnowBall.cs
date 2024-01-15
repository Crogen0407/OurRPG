using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : Enemy
{
    //Components
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject _snowEffect;
    
    protected override void Init()
    {
        spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetInt("_Seed", Random.Range(-1000, 1000));
        StartCoroutine(CreateSnowCoroutine());
    }

    private IEnumerator CreateSnowCoroutine()
    {
        while (!_gameManager.GameOver)
        {
            yield return new WaitForSeconds(0.25f);
            _poolManager.Pop("vfx_Snow", transform.position + Vector3.down * 0.75f, Quaternion.identity);
        }
    }
}
