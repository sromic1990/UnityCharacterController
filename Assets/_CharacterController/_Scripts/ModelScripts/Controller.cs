using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public abstract class Controller : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected bool _newInput;
    protected Collider _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

    }
    
    public abstract void ReadInput(InputData data);
}
