using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Material _defaultMaterial;
    [SerializeField] private Material _damagedMaterial;
    
    //Components
    public HealthSystem HealthSystem { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAttack PlayerAttack { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    
    void Awake()
    {
        HealthSystem = GetComponent<HealthSystem>();
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerAttack = GetComponent<PlayerAttack>();
        SpriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        
        _defaultMaterial = SpriteRenderer.material;
        
        HealthSystem.OnHpDownEvent = () =>
        {
            StopCoroutine(DamagedCoroutine());
            StartCoroutine(DamagedCoroutine());
        };
        HealthSystem.OnDieEvent = () =>
        {
            GameManager.Instance.GameOver = true;
        };
    }

    private IEnumerator DamagedCoroutine()
    {
        SpriteRenderer.material = _damagedMaterial;
        yield return new WaitForSeconds(0.1f);
        SpriteRenderer.material = _defaultMaterial;
    }
}
