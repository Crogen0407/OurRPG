using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] float _smoothing = 0.2f;
    [SerializeField] private Vector3 _speed = Vector3.one;
    private void Update()
    {
        if (Vector3.Distance(targetTransform.position, transform.position) > 2)
        {
            Vector3 targetPos = new Vector3(targetTransform.position.x, targetTransform.position.y, this.transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _speed, _smoothing);
        }
    }
}
