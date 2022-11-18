using Godot;
using Godot.Collections;

namespace Dingcodeeditorgodot.scripts.UI.Menu;

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