using Dingcodeeditorgd.scripts.Model;
using Dingcodeeditorgd.scripts.UI;
using Godot;

namespace Dingcodeeditorgd.scripts.Handlers
{
    public class ContHandlers
    {
        public static  BtnodeGraphNode CreateFromIdName(string idName)
        {
            var model = new MBtnode
            {
                SlotType= BtNodeSlotType.RootOutSlot, 
                ModelType = BtNodeModelType.Root,    
                NickName =  idName, 
                IdName = idName, 
                Tid = "1"
            };
            var gNode = new BtnodeGraphNode(model);
            return gNode;
        }

        public static PopupMenu CreateRightMenuPop()
        {
            var popMenu = new RightClickPopMenu();
            return popMenu;
        }
    }
}