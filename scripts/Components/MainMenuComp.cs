using System;
using Godot;
using Handlers;

namespace Components
{
    public class MainMenuComp : Node
    {
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
            foreach (var mName in Enum.GetNames(typeof(FileMenu))) pop.AddItem(mName);

            AddChild(fMenu);
        }

        private void _OnFileMenuPressed(int index)
        {
            GD.Print($"menu pressed index = {index}");
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

        private void _OnFileSelect(string path, FileDialog.ModeEnum oType)
        {
            GD.Print($"file select type is ->\n path = {path}, otype={oType.ToString()}");
            // switch (oType)
            // {
            //     case FileDialog.ModeEnum.OpenFile:
            //         var cont = File.ReadAllText(path);
            //         JsonData ret = JsonMapper.ToObject(cont);
            //         break;
            //     case FileDialog.ModeEnum.SaveFile:
            //         var treeModel = 
            //         File.WriteAllText();
            // }
        }

        private enum FileMenu
        {
            Open = 0,
            Save = 1,
            Export = 2
        }
    }
}