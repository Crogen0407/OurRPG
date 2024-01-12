using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingletonOneScene<GameManager>
{
    public bool isGameOver;

    public PlayerMovement PlayerMovement { get; private set; }
    public HealthSystem PlayerHealthSystem { get; private set; }
    

    void Awake()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        PlayerHealthSystem = PlayerMovement.GetComponent<HealthSystem>();
    }
}
