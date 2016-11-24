//-----------------------------------------------------------------
// This script handles the TidyUp MenuItem.
// It hosts the main Extension functions for calling project Core functionality in the editor.
// TODO: 
// [X] Initialize Project Folders			Main Function
// [X] Clean Up My Mess			            Main Function
// [ ] Create My Own Style                  Main Function
//
//-----------------------------------------------------------------

using UnityEditor;
public class TidyUp : EditorWindow
{
    [MenuItem("Tidy Up/Initialize Project Folders")]
    [MenuItem("Assets/Initialize Project Folders", false, 1)]
    private static void InitializeProjectFolders()
    {
        TidyUpCore.CreateFolders();
    }

    [MenuItem("Tidy Up/Clean Up my Mess")]
    [MenuItem("Assets/Clean Up my Mess", false, 2)]
    private static void CleanUpMyMess()
    {
        //Create Missing Directory if there is any
        TidyUpCore.CreateFolders();

        //Move Files In Root level to Appropriate Directory
        TidyUpCore.CleanRootDirectory();
    }

    [MenuItem("Tidy Up/Options")]
    internal static void Options()
    {
        //TidyUpSettingUI opWindow = (TidyUpSettingUI)EditorWindow.GetWindow(typeof(TidyUpSettingUI), false, "TidyUp Setting", true);

        var editorAsm = typeof(Editor).Assembly;
        var inspWndType = editorAsm.GetType("UnityEditor.InspectorWindow"); //get type of InspectorWindow
        TidyUpSettingUI opWindow = EditorWindow.GetWindow<TidyUpSettingUI>("TidyUp Setting", true, inspWndType);

        opWindow.Show();
    }

}