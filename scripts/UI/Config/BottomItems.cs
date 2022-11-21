using Godot;
using Godot.Collections;

namespace Dingcodeeditorgd.scripts.UI.Config
{
    /// <summary>
    /// Menu-File
    /// </summary>
    public enum FileItems 
    {
        Open,
        Save,
        Export
    }


    /// <summary>
    /// MenuBottoms
    /// </summary>
    public struct MenuBottoms
    {
        public FileItems File;
    }
}