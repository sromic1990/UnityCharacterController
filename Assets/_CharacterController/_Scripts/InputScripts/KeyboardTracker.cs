using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTracker : DeviceTracker
{
    [SerializeField] private AxisButtons[] axisKeys;
    [SerializeField] private KeyCode[] buttonKeys;

    private void Reset()
    {
        _inputManager = GetComponent<InputManager>();
        axisKeys = new AxisButtons[_inputManager.AxisCount];
        buttonKeys = new KeyCode[_inputManager.ButtonCount];
    }

    void Update()
    {
        //Inputs are detected, set new data to true
        //populate InputData to pass to the InputManager

        //Value
        for (int i = 0; i < axisKeys.Length; i++)
        {
            float value = 0;
            
            if (Input.GetKey(axisKeys[i].positive))
            {
                value += 1;
                _isNewDataAvailable = true;
            }
            if (Input.GetKey(axisKeys[i].negative))
            {
                value -= 1;
                _isNewDataAvailable = true;
            }

            _inputData.axes[i] = value;
        }
        
        //Buttons
        for (int i = 0; i < buttonKeys.Length; i++)
        {
            if (Input.GetKey(buttonKeys[i]))
            {
                _inputData.buttons[i] = true;
                _isNewDataAvailable = true;
            }
        }

        if (_isNewDataAvailable)
        {
            _inputManager.PassInput(_inputData);
            _isNewDataAvailable = false;
            _inputData.Reset();
        }
    }
}

[System.Serializable]
public struct AxisButtons
{
    public KeyCode positive;
    public KeyCode negative;
}
