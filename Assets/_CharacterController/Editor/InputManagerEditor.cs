using UnityEditor;

[CustomEditor(typeof(InputManager))]
public class InputManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InputManager _inputManager = target as InputManager;
        
        EditorGUI.BeginChangeCheck();
        
        base.OnInspectorGUI();

        if (EditorGUI.EndChangeCheck())
        {
            _inputManager.RefreshTracker();
        }
    }
}
