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

        EditorGUILayout.BeginHorizontal(); GUILayout.Space(2); //Top Setting Group
        if (GUILayout.Button("Import Setting"))
        {
            //Not Implemented Yet
        }
        if (GUILayout.Button("Export Setting"))
        {
            //Not Implemented Yet
        }
        GUILayout.Space(20);
        if (GUILayout.Button("Reset"))
        {
            this.Close(); //Destroy window resource
            TidyUpCore.RestSetting();
            TidyUp.Options(); //Instantiate new instance
        }
        GUILayout.Space(2); EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);    //Folder Template Setting
        EditorGUILayout.PropertyField(folderTemplateProperty, new GUIContent("Folders Template List"), true); // True means show children
        serializedObject.ApplyModifiedProperties(); // Remember to apply modified properties

        GUILayout.Space(10); //Button Setting Group
        EditorGUILayout.BeginHorizontal(); GUILayout.Space(Screen.width / 4);
        GUI.backgroundColor = Color.grey;
        if (GUILayout.Button("Save Settings", GUILayout.Width(150), GUILayout.Height(30)))
        {
            TidyUpCore.StoreSetting(folderTemplate);
        }
        GUILayout.Space(10); EditorGUILayout.EndHorizontal();
    }
}