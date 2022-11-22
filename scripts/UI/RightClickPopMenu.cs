using System;
using Dingcodeeditorgd.scripts.Model;
using Godot;
using Godot.Collections;
using Array = Godot.Collections.Array;
using Dictionary = Godot.Collections.Dictionary;

namespace Dingcodeeditorgd.scripts.UI
{
    public class RightClickPopMenu : PopupMenu
    {
        private Dictionary<BtNodeModelType, PopupMenu> _mSubMenus = new Dictionary<BtNodeModelType, PopupMenu>();
        private Array _mSubTypes = new Array();
        
        /// <summary>
        ///
        /// Sigal: emit when select the item to create the btnode graph
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="btName"></param>
        [Signal]
        public delegate void select_item(BtNodeModelType mType, string btName);

        // [Signal]
        // delegate void _onMenuPressed();

        enum HandlerIDs
        {
            // root,  define by enum real value 
        }

        public RightClickPopMenu()
        {
            //main
            foreach (var val in Enum.GetValues(typeof(BtNodeModelType)))
            {
                _mSubTypes.Add(val.ToString());
                _initSubMenus(val is BtNodeModelType ? (BtNodeModelType) val : BtNodeModelType.Root);
                AddSubmenuItem(val.ToString(), val.ToString());
            }
        }

        private void _initSubMenus(BtNodeModelType pType)
        {
            if (_mSubMenus.ContainsKey(pType)) return;
            var subPm = new PopupMenu();
            subPm.AddItem("test");
            subPm.Name = pType.ToString();
            subPm.Connect("id_pressed", this, "_onMenuPressed", new Array {pType});
            AddChild(subPm);
            _mSubMenus[pType] = subPm;
        }

        private void _onMenuPressed(int i, BtNodeModelType mType)
        {
            EmitSignal(nameof(select_item), mType, i);
            GD.Print($"menu item pressed is {i} type is {mType}");
        }
    }
}