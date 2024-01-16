using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputController : MonoBehaviour
{
    public List<InputEvent> inputEvents;
    
    void Update()
    {
        foreach (var inputEvent in inputEvents)
        {
            if (Input.GetKeyDown(inputEvent.keyCode))
            {
                inputEvent.unityEvent?.Invoke();
            }
        }
    }
}

[Serializable]
public struct InputEvent
{
    public KeyCode keyCode;
    public UnityEvent unityEvent;
}