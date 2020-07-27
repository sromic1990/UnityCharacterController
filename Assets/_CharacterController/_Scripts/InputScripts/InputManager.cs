using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region FIELDS
    [Range(0, 10)] 
    [SerializeField] private int axisCount;
    public int AxisCount
    {
        get { return axisCount; }
    }

    [Range(0, 20)] 
    [SerializeField] private int buttonCount;
    public int ButtonCount
    {
        get { return buttonCount; }
    }

    [SerializeField] private Controller _controller;
    #endregion
    
    #region METHODS
    public void PassInput(InputData data)
    {
        // Debug.Log("Movement: " + data.axes[0] + " , " + data.axes[1]);
        _controller.ReadInput(data);
    }

    public void RefreshTracker()
    {
        DeviceTracker dt = GetComponent<DeviceTracker>();
        if (dt != null)
        {
            dt.Refresh();
        }
    }
    #endregion
}

[System.Serializable]
public struct InputData
{
    public float[] axes;
    public bool[] buttons;

    public InputData(int axisCount, int buttonCount)
    {
        axes = new float[axisCount];
        buttons = new bool[buttonCount];
    }

    public void Reset()
    {
        for (int i = 0; i < axes.Length; i++)
        {
            axes[i] = 0f;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = false;
        }
    }
}
