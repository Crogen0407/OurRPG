using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    //Components
    private SpriteRenderer spriteRenderer;
    
    protected override void Init()
    {
        spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetInt("_Seed", Random.Range(-1000, 1000));
    }
}
