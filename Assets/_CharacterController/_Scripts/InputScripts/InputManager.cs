using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
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
    
    public void PassInput(InputData data)
    {
        Debug.Log("Movement: " + data.axes[0] + " , " + data.axes[1]);
    }
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
