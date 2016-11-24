//-----------------------------------------------------------------
// This script Used for storing the default Project Folder Structure.
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

[Serializable]
public class FolderTemplate
{
    public string folderName;
    public string folderPath;
}

[System.Serializable]
public class FolderTemplateList
{
    public List<FolderTemplate> folderTemplate = new List<FolderTemplate>();
}

public enum FolderStructure
{
    _Scenes,
    _ImportedAssets,
    Animation,
    Audio,
    Fonts,
    Materials,
    Prefabs,
    Scripts,
    Textures,
}