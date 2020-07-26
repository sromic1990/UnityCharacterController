using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingController : Controller
{
    [SerializeField] private float walkSpeed = 3;
    
    Vector3 walkVelocity;

    public override void ReadInput(InputData data)
    {
        //Vertical movement
        if (data.axes[0] != 0f)
        {
            walkVelocity += Vector3.forward * data.axes[0] * walkSpeed * Time.deltaTime;
        }
        
        //Horizontal movement
        if (data.axes[1] != 0f)
        {
            walkVelocity += Vector3.right * data.axes[1] * walkSpeed * Time.deltaTime;
        }

        newInput = true;
    }

    private void LateUpdate()
    {
        if (!newInput)
        {
            walkVelocity = Vector3.zero;
        }
        
        _rigidbody.velocity = new Vector3(walkVelocity.x, _rigidbody.velocity.y, walkVelocity.z);
        newInput = false;
    }
}
