using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTracker : DeviceTracker
{
    void Update()
    {
        //Inputs are detected, set new data to true
        //populate InputData to pass to the InputManager

        if (_isNewDataAvailable)
        {
            _inputManager.PassInput(_inputData);
            _isNewDataAvailable = false;
            _inputData.Reset();
        }
    }
}
