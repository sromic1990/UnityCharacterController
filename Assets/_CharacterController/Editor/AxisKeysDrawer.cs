using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AxisKeys))]
public class AxisKeysDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Ensure override works on entire property
        EditorGUI.BeginProperty(position, label, property);
        
        //Dont indent
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        
        //label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        
        //Set position rect
        Rect positive_Label = new Rect(position.x, position.y, 15, position.height);
        Rect positive_Field = new Rect(position.x + 20, position.y, 50, position.height);
        Rect negative_Label = new Rect(position.x + 75, position.y, 15, position.height);
        Rect negative_Field = new Rect(position.x + 95, position.y, 50, position.height);
        
        //Set Labels
        GUIContent positive_GUI = new GUIContent("+");
        GUIContent negative_GUI = new GUIContent("-");
        
        //Draw fields
        EditorGUI.LabelField(positive_Label, positive_GUI);
        EditorGUI.PropertyField(positive_Field, property.FindPropertyRelative("positive"), GUIContent.none);
        EditorGUI.LabelField(negative_Label, negative_GUI);
        EditorGUI.PropertyField(negative_Field, property.FindPropertyRelative("negative"), GUIContent.none);

        //Reset Indent
        EditorGUI.indentLevel = indent;
        
        //End Property
        EditorGUI.EndProperty();
    }
}
