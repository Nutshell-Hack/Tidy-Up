//-----------------------------------------------------------------
// This script handles the TidyUp Core System.
// It hosts the main Extension functions for manipulating project in the editor.
// TODO: 
// [X] Initialize Project Folders			Main Function
// [X] Clean Up My Mess			            Main Function
// [X] Create My Own Style                  Main Function
// [X] Import/Export Setting                New Function
// [X] Reset Setting                        New Function
// [X] Link `CleanRootDirectory` with the new UI
//-----------------------------------------------------------------

using System;
using System.IO;
using UnityEditor;
using UnityEngine;
public class TidyUpCore
{
    public static FolderTemplate folderTemplate = new FolderTemplate();
    private static string pathToResource = "TidyUp/Plugins/Editor/Data.json";

    internal static void CreateFolders()
    {
        folderTemplate = LoadSetting(); //populate folderTemplate with data

        foreach (var _folder in folderTemplate.folderTemplateList)
        {
            bool isExists = AssetDatabase.IsValidFolder("Assets" + _folder.folderName);
            if (isExists) //Skip Creating folder if it's already Exist
                continue;

            //Otherwise Create Folder
            Directory.CreateDirectory(Path.Combine(Application.dataPath + _folder.folderPath, _folder.folderName));
        }
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    internal static void CleanRootDirectory()
    {
        folderTemplate = LoadSetting(); //populate folderTemplate with data

        DirectoryInfo dir = new DirectoryInfo(Application.dataPath);
        FileInfo[] info = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly); //get only files in root Directory

        var _scenesFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Scenes);
        var _animationsFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Animations);
        var _audioFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Audio);
        var _fontsFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Fonts);
        var _materialsFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Materials);
        var _modelsFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Models);
        var _texturesFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Textures);
        var _prefabsFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Prefabs);
        var _scriptsFolder = folderTemplate.folderTemplateList.Find(item => item.assetType == AssetType.Scripts);

        foreach (FileInfo file in info) //Loop over root files
        {
            int extensionPos = file.ToString().IndexOf(".");
            string extension = file.ToString().Substring(extensionPos).ToLower();

            if (extension == ".unity" || extension == ".unity.meta")    //if file is Scene
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _scenesFolder.folderPath + _scenesFolder.folderName, file.Name));
            }
            else if (extension == ".anim" || extension == ".anim.meta")   //if file is Animation
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _animationsFolder.folderPath + _animationsFolder.folderName, file.Name));
            }
            else if (extension == ".mp3" || extension == ".mp3.meta" || extension == ".ogg" || extension == ".ogg.meta" ||
             extension == ".wav" || extension == ".wav.meta" || extension == ".mod" || extension == ".mod.meta" ||
             extension == ".it" || extension == ".it.meta" || extension == ".s3m" || extension == ".s3m.meta" ||
             extension == ".xm" || extension == ".xm.meta" || extension == ".aiff" || extension == ".aiff.meta" ||
             extension == ".aif" || extension == ".aif.meta")   //if file is Audio
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _audioFolder.folderPath + _audioFolder.folderName, file.Name));
            }
            else if (extension == ".ttf" || extension == ".ttf.meta" || extension == ".otf" || extension == ".otf.meta")   //if file is Font
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _fontsFolder.folderPath + _fontsFolder.folderName, file.Name));
            }
            else if (extension == ".mat" || extension == ".mat.meta")   //if file is Material
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _materialsFolder.folderPath + _materialsFolder.folderName, file.Name));
            }
            else if (extension == ".fbx" || extension == ".fbx.meta" || extension == ".dae" || extension == ".dae.meta" ||
            extension == ".dxf" || extension == ".dxf.meta" || extension == ".obj" || extension == ".obj.meta" ||
            extension == ".max" || extension == ".max.meta" || extension == ".blend" || extension == ".blend.meta")   //if file is Model
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _modelsFolder.folderPath + _modelsFolder.folderName, file.Name));
            }
            else if (extension == ".bmp" || extension == ".bmp.meta" || extension == ".exr" || extension == ".exr.meta" ||
            extension == ".gif" || extension == ".gif.meta" || extension == ".hdr" || extension == ".hdr.meta" ||
            extension == ".iff" || extension == ".iff.meta" || extension == ".jpg" || extension == ".jpg.meta" ||
            extension == ".pict" || extension == ".pict.meta" || extension == ".png" || extension == ".png.meta" ||
            extension == ".psd" || extension == ".psd.meta" || extension == ".tga" || extension == ".tga.meta" ||
            extension == ".tiff" || extension == ".tiff.meta")   //if file is Texture
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _texturesFolder.folderPath + _texturesFolder.folderName, file.Name));
            }
            else if (extension == ".prefab" || extension == ".prefab.meta")   //if file is Prefab
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _prefabsFolder.folderPath + _prefabsFolder.folderName, file.Name));
            }
            else if (extension == ".cs" || extension == ".cs.meta")   //if file is Script
            {
                AssetDatabase.MoveAsset(
                    "Assets/" + file.Name,
                    Path.Combine("Assets" + _scriptsFolder.folderPath + _scriptsFolder.folderName, file.Name));
            }
        }
    }

    /// <summary>
    /// LoadSetting() is called from `TidyUpSettingUI` to read Data.json file
    /// and populate the FolderTemplateList with data
    /// </summary>
    internal static FolderTemplate LoadSetting()
    {
        string json = "";
        try
        { json = File.ReadAllText(Path.Combine(Application.dataPath, pathToResource)); }
        catch (System.Exception) //In case Data.json  deleted somehow
        { RestSetting(); return new FolderTemplate(); } //Reset Data file

        folderTemplate = JsonUtility.FromJson<FolderTemplate>(json);    //retrieve JSON to object

        return folderTemplate;
    }
    internal static void StoreSetting(FolderTemplate template)
    {
        string json = JsonUtility.ToJson(template); //save as JSON

        File.WriteAllText(Path.Combine(Application.dataPath, pathToResource), json); //store json to file
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    internal static void ImportSetting()
    {
        string path = EditorUtility.OpenFilePanel("Import New Setting", Application.dataPath, "json");

        if (path.Length != 0)
        {
            string json = "";
            try
            {
                json = File.ReadAllText(path);

                //wrapper the json into `FolderTemplate` to make sure it's valid data file
                folderTemplate = JsonUtility.FromJson<FolderTemplate>(json);
                if (folderTemplate == null) //Invalid Data file
                    throw new InvalidDataException();
            }
            catch (System.Exception) //In case Data.json  corrupted
            {
                EditorUtility.DisplayDialog("Import New Setting", "You must select a valid JSON data file!", "OK");
                return;
            }

            File.WriteAllText(Path.Combine(Application.dataPath, pathToResource), json); //store json to file
        }

    }

    internal static void ExportSetting(FolderTemplate template)
    {
        string path = EditorUtility.SaveFilePanel("Export Setting", Application.dataPath, "Data", "json");
        if (path.Length != 0)
        {
            string json = JsonUtility.ToJson(template); //save as JSON
            File.WriteAllText(path, json); //store json to file
        }
    }

    /// <summary>
    /// ClearConsole() is called on the frame when we release `folderTemplate` just before
    /// any of the Update methods to data populate.
    /// </summary>
    internal static void ClearConsole()
    {
        // This simply does "LogEntries.Clear()" the long way:
        var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }

    // for testing purpose
    internal static void RestSetting()
    {
        folderTemplate.folderTemplateList.Clear(); //make sure the list is empty 

        foreach (var item in Enum.GetValues(typeof(FolderStructure))) //populate list with enum data
        {
            Folder FT = new Folder();
            FT.folderName = item.ToString();

            //Exception for Graphic Content
            if (item.ToString() == "Materials" || item.ToString() == "Models" || item.ToString() == "Textures")
                FT.folderPath = @"\Graphics\";
            else
                FT.folderPath = @"\";

            try //Match `AssetType` with the default `FolderStructure`
            { FT.assetType = (AssetType)Enum.Parse(typeof(AssetType), item.ToString()); }
            catch (System.Exception)
            {
                if (item.ToString() == "_Scenes")
                    FT.assetType = AssetType.Scenes;
                else
                    FT.assetType = AssetType.Other;
            }

            folderTemplate.folderTemplateList.Add(FT);
        }

        string json = JsonUtility.ToJson(folderTemplate); //convert list to json string

        File.WriteAllText(Path.Combine(Application.dataPath, pathToResource), json); //store json to file

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}