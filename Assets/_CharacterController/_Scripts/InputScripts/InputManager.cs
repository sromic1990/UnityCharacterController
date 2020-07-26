using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public void PassInput(InputData data)
    {
        
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
