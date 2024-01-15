using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthSystem))]
public abstract class Enemy : MonoBehaviour
{
    public string enemyType;
    public float moveSpeed = 8;
    public float intersection = 0.5f;
    public float damage = 1f;
    public Material damagedMaterial;
    private Material _defaultMaterial;
    private int _hp;
    [SerializeField] private GameObject dieEffect;
    
    //Components
    protected HealthSystem healthSystem;
    private float _defaultHp = 0.0f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    
    //Controllers
    private EnemySpawnController _enemySpawnController;
        
    //Managements
    protected PoolManager _poolManager;
    protected GameManager _gameManager;
    
    private void OnEnable()
    {
        //Managements
        _poolManager = PoolManager.Instance;
        _gameManager = GameManager.Instance;
        
        //Controllers
        _enemySpawnController = _gameManager.EnemySpawnController;
        
        //Components
        _rigidbody = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();

        if (_defaultHp == 0.0f)
            _defaultHp = healthSystem.Hp;
        else
        {
            healthSystem.Hp = _defaultHp;
        }
            
        _defaultMaterial = _spriteRenderer.material;
        
        healthSystem.OnDieEvent = () =>
        {
            _enemySpawnController.currentEnemies.Remove(this);
            StopCoroutine(DamagedCoroutine());
            if (dieEffect != null)
            {
                Instantiate(dieEffect, transform.position, Quaternion.identity);
            }
            _poolManager.Push(enemyType, gameObject);
            _gameManager.CheckGameClear();
        };
        healthSystem.OnHpDownEvent = () =>
        {
            StopCoroutine(DamagedCoroutine());
            StartCoroutine(DamagedCoroutine());
        };
        Init();
    }

    private void FixedUpdate()
    {
        Vector2 dir = (PlayerMovement.PlayerPosition - transform.position).normalized;
        float distance = Vector2.Distance(PlayerMovement.PlayerPosition, transform.position);

        if (distance > intersection)
        {
            _rigidbody.velocity = dir * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<HealthSystem>().Hp -= damage;
        }
        else if (other.transform.CompareTag("PlayerAttack"))
        {
            healthSystem.Hp--;
        }
    }
    
    private IEnumerator DamagedCoroutine()
    {
        _spriteRenderer.material = damagedMaterial;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.material = _defaultMaterial;
    }

    protected abstract void Init();
}
