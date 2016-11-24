//-----------------------------------------------------------------
// This script Used for storing the default Project Folder Structure.
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

[Serializable]
public class Folder
{
    public string folderName;
    public string folderPath;
}

[System.Serializable]
public class FolderTemplate
{
    public List<Folder> folderTemplateList = new List<Folder>();

    //Constructors
    public FolderTemplate() { }
    public FolderTemplate(List<Folder> folderTemplateList)
    {
        this.folderTemplateList = folderTemplateList;
    }
}

public enum FolderStructure
{ //Backup Structure
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