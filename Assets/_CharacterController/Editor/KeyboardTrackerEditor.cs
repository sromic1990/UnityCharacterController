using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(KeyboardTracker))]
public class KeyboardTrackerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        KeyboardTracker tracker = target as KeyboardTracker;
        
        EditorGUILayout.LabelField("Axes", EditorStyles.boldLabel);

        if (tracker.AxisKeys.Length == 0)
        {
            EditorGUILayout.HelpBox("No axes defined in Input Manager", MessageType.Info);
        }
        else
        {
            SerializedProperty prop = serializedObject.FindProperty("axisKeys");
            for (int i = 0; i < tracker.AxisKeys.Length; i++)
            {
                EditorGUILayout.PropertyField(prop.GetArrayElementAtIndex(i), new GUIContent("Axis "+i));
            }
        }

        EditorGUILayout.Space();
        
        EditorGUILayout.LabelField("Buttons", EditorStyles.boldLabel);

        if (tracker.ButtonKeys.Length == 0)
        {
            EditorGUILayout.HelpBox("No buttons defined in Input Manager", MessageType.Info);
        }
        else
        {
            for (int i = 0; i < tracker.ButtonKeys.Length; i++)
            {
                tracker.ButtonKeys[i] = (KeyCode)EditorGUILayout.EnumPopup("Button " + i, tracker.ButtonKeys[i]);
            }
        }

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
