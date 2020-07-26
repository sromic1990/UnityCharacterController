using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTracker : DeviceTracker
{
    [SerializeField] private AxisKeys[] axisKeys;
    public AxisKeys[] AxisKeys
    {
        get { return axisKeys; }
    }
    
    [SerializeField] private KeyCode[] buttonKeys;
    public KeyCode[] ButtonKeys
    {
        get { return buttonKeys; }
    }

    private void Reset()
    {
        _inputManager = GetComponent<InputManager>();
        axisKeys = new AxisKeys[_inputManager.AxisCount];
        buttonKeys = new KeyCode[_inputManager.ButtonCount];
    }

    public override void Refresh()
    {
        _inputManager = GetComponent<InputManager>();
        KeyCode[] newButtons = new KeyCode[_inputManager.ButtonCount];
        if (buttonKeys != null)
        {
            for (int i = 0; i < Mathf.Min(newButtons.Length, buttonKeys.Length); i++)
            {
                newButtons[i] = buttonKeys[i];
            }
        }
        buttonKeys = newButtons;
        
        AxisKeys[] newAxis = new AxisKeys[_inputManager.AxisCount];
        if (axisKeys != null)
        {
            for (int i = 0; i < Mathf.Min(newAxis.Length, axisKeys.Length); i++)
            {
                newAxis[i] = axisKeys[i];
            }
        }
        axisKeys = newAxis;
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
public struct AxisKeys
{
    public KeyCode positive;
    public KeyCode negative;
}
