using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FacingDirection
{
    North,
    East,
    South,
    West
}

public class WalkingController : Controller
{
    //Settings
    [SerializeField] private float walkSpeed = 3;
    [SerializeField] private float jumpSpeed = 6;
    
    //Movement Information
    private Vector3 walkVelocity;
    private Vector3 prevWalkVelocity;
    private float adjustedVerticalVelocity;
    private float jumpPressTime;
    private FacingDirection facing;

    public override void ReadInput(InputData data)
    {
        prevWalkVelocity = walkVelocity;
        ResetMovementToZero();
        
        //Vertical movement
        if (data.axes[0] != 0f)
        {
            walkVelocity += Vector3.forward * data.axes[0] * walkSpeed;
        }
        
        //Horizontal movement
        if (data.axes[1] != 0f)
        {
            walkVelocity += Vector3.right * data.axes[1] * walkSpeed;
        }
        
        //Set vertical jump
        if (data.buttons[0])
        {
            if (jumpPressTime < Time.deltaTime)
            {
                if (IsGrounded())
                {
                    adjustedVerticalVelocity = jumpSpeed;
                }
            }
            jumpPressTime += Time.deltaTime;
        }
        else
        {
            jumpPressTime = 0;
        }

        _newInput = true;
    }

    private bool IsGrounded()
    {
        //will look below our character and see if there is a collider
        return Physics.Raycast(transform.position, Vector3.down, _collider.bounds.extents.y + 0.1f);
    }

    private void LateUpdate()
    {
        if (!_newInput)
        {
            prevWalkVelocity = walkVelocity;
            ResetMovementToZero();
            jumpPressTime = 0f;
        }

        if (prevWalkVelocity != walkVelocity)
        {
            //Check if there is a face change
            CheckForFacingChange();
        }

        _rigidbody.velocity = new Vector3(walkVelocity.x, _rigidbody.velocity.y + adjustedVerticalVelocity, walkVelocity.z);
        _newInput = false;
    }

    private void CheckForFacingChange()
    {
        //Moving and suddenly stop - no change face
        if(walkVelocity == Vector3.zero)
            return;

        if (walkVelocity.x == 0f || walkVelocity.z == 0f)
        {
            //change our facing based on walk velocity
            ChangeFacing(walkVelocity);
        }
        else
        {
            if (prevWalkVelocity.x == 0)
            {
                ChangeFacing(new Vector3(walkVelocity.x, 0, 0));
            }
            else if (prevWalkVelocity.z == 0)
            {
                ChangeFacing(new Vector3(0, 0, walkVelocity.z));
            }
            else
            {
                Debug.LogWarning("Unexpected Walk velocity value = "+walkVelocity);
                ChangeFacing(walkVelocity);
            }
        }
    }
    
    //NOTE: Method assumes only X or Z value will be non zero in the direction parameter, will default to Z Value
    private void ChangeFacing(Vector3 direction)
    {
        if (direction.z != 0)
        {
            facing = (direction.z > 0) ? FacingDirection.North : FacingDirection.South;
        }
        else if (direction.x != 0)
        {
            facing = (direction.x > 0) ? FacingDirection.East : FacingDirection.West;
        }
    }

    private void ResetMovementToZero()
    {
        walkVelocity = Vector3.zero;
        adjustedVerticalVelocity = 0f;
    }
}
