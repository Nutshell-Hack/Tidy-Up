using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
public class TidyUp : EditorWindow
{
    [MenuItem("Tidy Up/Initialize Project Folders")]
    static void InitializeProjectFolders()
    {
        // string guid = AssetDatabase.CreateFolder("Assets", "My Folder");
        // string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        foreach (FolderStructure _folderName in Enum.GetValues(typeof(FolderStructure)))
        {
            AssetDatabase.CreateFolder("Assets", _folderName.ToString());
        }
    }
}