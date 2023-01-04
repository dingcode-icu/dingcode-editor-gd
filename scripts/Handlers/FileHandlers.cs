using Godot;
using Godot.Collections;

namespace Handlers
{
    public class FileHandlers
    {
        private static FileDialog _ShowFileDialog(Node ctx, FileDialog.ModeEnum eMod)
        {
            var fd = new FileDialog();
            ctx.AddChild(fd);
            fd.Resizable = true;
            var winSize = OS.GetWindowSafeArea();
            fd.SetSize(new Vector2(winSize.Size.x / 2, winSize.Size.y / 2));
            fd.Mode = eMod;
            fd.Access = FileDialog.AccessEnum.Filesystem;
            fd.Filters = new[] { "*.ding", "*.ding.json" };
            fd.PopupCentered();
            return fd;
        }

        public static void ReadFile(Node ctx)
        {
            var fd = _ShowFileDialog(ctx, FileDialog.ModeEnum.OpenFile);
            fd.Connect("file_selected", ctx, "_OnFileSelect", new Array
            {
                FileDialog.ModeEnum.OpenFile
            });
        }

        public static void SaveFile(Node ctx)
        {
            var fd = _ShowFileDialog(ctx, FileDialog.ModeEnum.SaveFile);
            fd.Connect("file_selected", ctx, "_OnFileSelect", new Array
            {
                FileDialog.ModeEnum.SaveFile
            });
        }
    }
}