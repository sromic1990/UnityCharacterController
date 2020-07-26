using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public abstract class DeviceTracker : MonoBehaviour
{
    protected InputManager _inputManager;
    protected InputData _inputData;
    protected bool _isNewDataAvailable;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }
}
