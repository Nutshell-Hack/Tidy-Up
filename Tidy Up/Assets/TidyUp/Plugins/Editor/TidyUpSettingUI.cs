//-----------------------------------------------------------------
// This script Used for handles the Settings GUI.
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class TidyUpSettingUI : EditorWindow
{
    public FolderTemplate folderTemplate;
    public List<Folder> list;

    ScriptableObject target;
    SerializedObject serializedObject;
    SerializedProperty folderTemplateProperty;

    void OnFocus()
    {
        folderTemplate = TidyUpCore.LoadSetting(); //LoadSetting
        list = folderTemplate.folderTemplateList;

        // "target" can be any class derived from ScriptableObject 
        // (could be EditorWindow, MonoBehaviour, etc)
        target = this;
        serializedObject = new SerializedObject(target);
        folderTemplateProperty = serializedObject.FindProperty("list");
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);

        EditorGUILayout.PropertyField(folderTemplateProperty, new GUIContent("Folders Template List"), true); // True means show children
        serializedObject.ApplyModifiedProperties(); // Remember to apply modified properties

        GUILayout.Space(10);
        if (GUILayout.Button("Save Settings"))
        {
            TidyUpCore.StoreSetting(folderTemplate);
        }
    }
}