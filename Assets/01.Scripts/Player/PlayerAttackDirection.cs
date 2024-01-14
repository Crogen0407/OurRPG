using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDirection : MonoBehaviour
{
    public static Vector2 Direction { get; private set; }

    void Update()
    {
        Direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        transform.up = Direction;
    }
}
