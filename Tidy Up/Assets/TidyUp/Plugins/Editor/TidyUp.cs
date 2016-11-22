//-----------------------------------------------------------------
// This script handles the TidyUp Core System.
// It hosts the main Extension functions for manipulating project in the editor.
// TODO: 
// [x] Initialize Project Folders			Main Function
// [ ] Clean Up My Mess			            Main Function
// [ ] Create My Own Style                  Main Function
//
//-----------------------------------------------------------------

using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
public class TidyUp : EditorWindow
{
    [MenuItem("Tidy Up/Initialize Project Folders")]
    [MenuItem("Assets/Initialize Project Folders", false, 1)]
    private static void InitializeProjectFolders()
    {
        foreach (FolderStructure _folderName in Enum.GetValues(typeof(FolderStructure)))
        {
            bool isExists = AssetDatabase.IsValidFolder("Assets/" + _folderName.ToString());
            if (isExists) //Skip Creating folder if it's already Exist
                continue;

            //Otherwise Create Folder
            AssetDatabase.CreateFolder("Assets", _folderName.ToString());
        }
    }
}