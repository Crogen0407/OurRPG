using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Material _defaultMaterial;
    [SerializeField] private Material _damagedMaterial;
    
    private int _maxExp = 100;
    private int _exp;
    
    //Components
    public HealthSystem HealthSystem { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAttack PlayerAttack { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    
    //Managements
    private GameScene_UIManager _uiManager;
    
    public int Exp
    {
        get => _exp;
        set
        {
            _exp = value;
            if (_exp >= _maxExp)
            {
                PowerUp();
            }
        }
    }
    
    void Awake()
    {
        //Managements
        _uiManager = GameScene_UIManager.Instance;
        
        //Components
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
        HealthSystem.OnHpChangeEvent = () =>
        {
            _uiManager.SetHpBarValue(HealthSystem.Hp/HealthSystem.MaxHp);
        };
        HealthSystem.OnDieEvent = () =>
        {
            GameManager.Instance.GameOver = true;
        };
    }

    private void PowerUp()
    {
        _maxExp *= 2;
        Exp = 0;
        _uiManager.ShowPowerUpPanel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            float damage = 1;
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
                damage = enemy.damage;
            HealthSystem.Hp -= damage;
        }
    }

    private IEnumerator DamagedCoroutine()
    {
        SpriteRenderer.material = _damagedMaterial;
        yield return new WaitForSeconds(0.1f);
        SpriteRenderer.material = _defaultMaterial;
    }
}
