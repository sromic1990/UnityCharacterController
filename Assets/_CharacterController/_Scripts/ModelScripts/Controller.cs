using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public abstract class Controller : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected bool newInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public abstract void ReadInput(InputData data);
}
