using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDirection : MonoBehaviour
{
    public static Vector2 Direction { get; private set; }
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    void Update()
    {
        if ((_gameManager.GameOver || _gameManager.GameClear || _gameManager.timeClear) == false)
        {
            Direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            transform.up = Direction;
        }
    }
}
