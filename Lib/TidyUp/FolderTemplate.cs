//-----------------------------------------------------------------
// This script Used for storing the default Project Folder Structure.
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace TidyUp
{

    [Serializable]
    public class Folder
    {
        public string folderName;
        public string folderPath;
        public AssetType assetType;
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
        Animations,
        Audio,
        Fonts,
        Materials,
        Models,
        Prefabs,
        Scripts,
        Textures,
    }

    public enum AssetType
    { //For Grouping porpuse
        Animations,
        Audio,
        Fonts,
        Materials,
        Models,
        Prefabs,
        Textures,
        Scenes,
        Scripts,
        Other,
    }
}
