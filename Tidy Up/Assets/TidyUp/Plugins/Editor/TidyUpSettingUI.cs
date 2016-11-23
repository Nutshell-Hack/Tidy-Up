//-----------------------------------------------------------------
// This script Used for handles the Settings GUI.
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
public class TidyUpSettingUI : EditorWindow
{
    public List<string> FolderStructureList = Enum.GetValues(typeof(FolderStructure))
       .Cast<FolderStructure>().Select(v => v.ToString()).ToList();

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);

        // "target" can be any class derived from ScriptableObject 
        // (could be EditorWindow, MonoBehaviour, etc)
        ScriptableObject target = this;
        SerializedObject serializedObject = new SerializedObject(target);
        SerializedProperty stringsProperty = serializedObject.FindProperty("FolderStructureList");

        EditorGUILayout.PropertyField(stringsProperty, true); // True means show children

        serializedObject.ApplyModifiedProperties(); // Remember to apply modified properties
    }
}