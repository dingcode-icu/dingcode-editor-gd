using Godot;
using Model;
using UI;

namespace Handlers
{
    public class ContHandlers
    {
        public static  BtnodeGraphNode CreateFromIdName(MBtnode m)
        {
            var gNode = new BtnodeGraphNode(m);
            return gNode;
        }

        public static PopupMenu CreateRightMenuPop()
        {
            var popMenu = new RightClickPopMenu();
            return popMenu;
        }
    }
}