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
    
    //Components
    protected HealthSystem healthSystem;
    private Rigidbody2D _rigidbody;
    
    //Managements
    protected PoolManager _poolManager;
    
    private void OnEnable()
    {
        _poolManager = PoolManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDieEvent = () =>
        {
            _poolManager.Push(enemyType, gameObject);
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

    protected abstract void Init();
}
