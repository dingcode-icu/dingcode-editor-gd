using Model;
using Godot;

namespace Handlers
{
    public class FileHandlers
    {
        private static FileDialog _ShowFileDialog(Node ctx, FileDialog.ModeEnum eMod)
        {
            var fd = new FileDialog();
            ctx.AddChild(fd);
            fd.Resizable = true;
            fd.Mode = eMod;
            fd.Access = FileDialog.AccessEnum.Filesystem;
            fd.PopupCentered();
            return fd;
        }

        public static void ReadFile(Node ctx)
        {
            var fd = _ShowFileDialog(ctx, FileDialog.ModeEnum.OpenFile);
            fd.Connect("file_selected", ctx, "_OnFileSelect");
        }

        public static void SaveFile(Node ctx)
        {
            var fd = _ShowFileDialog(ctx, FileDialog.ModeEnum.SaveFile);
            fd.Connect("file_select", ctx, "OnFileSelect");
        }
}
}