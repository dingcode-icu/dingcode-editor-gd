using System;
using Godot;
using Godot.Collections;
using Handlers;
using Array = Godot.Collections.Array;

namespace Components
{
    public class MainMenuComp : Control
    {

        enum FileMenu
        {
            Open = 0,
            Save = 1,
            Export = 2,
        }
        
        public override void _Ready()
        {
             base._Ready();
            _InitMenuButtons();
        }

        private void _InitMenuButtons()
        {
            var fMenu = new MenuButton();
            fMenu.Text = "File";
            var pop = fMenu.GetPopup();
            pop.Connect("index_pressed", this, nameof(_OnFileMenuPressed));
            foreach (var mName in Enum.GetNames(typeof(FileMenu)))
            {
                pop.AddItem(mName);
            }
            AddChild(fMenu);
        }

        private void _OnFileMenuPressed(int index, string mName)
        {
            GD.Print($"menu pressed index = {index}, mName = {mName}");
            switch (index)
            {
                case 0: 
                    FileHandlers.ReadFile(this);
                    break;
                case 1:
                    FileHandlers.SaveFile(this);
                    break;
                default:
                    GD.Print("no handler yet!");
                    break;
            }  
        }
    }
}