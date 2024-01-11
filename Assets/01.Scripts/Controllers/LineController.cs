using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    [SerializeField] private Transform[] stagePoint;
    private LineRenderer _lineRenderer;
    
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        LoadLine();
    }

    private void LoadLine()
    {
        _lineRenderer.positionCount = stagePoint.Length;
        for (int i = 0; i < stagePoint.Length; i++)
        {
            _lineRenderer.SetPosition(i, stagePoint[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
