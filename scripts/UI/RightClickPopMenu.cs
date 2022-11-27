using System;
using Godot;
using Godot.Collections;
using Model;
using Array = Godot.Collections.Array;

namespace UI
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
                _InitSubMenus(val is BtNodeModelType ? (BtNodeModelType) val : BtNodeModelType.Root);
                AddSubmenuItem(val.ToString(), val.ToString());
            }
        }

        private void _InitSubMenus(BtNodeModelType pType)
        {
            if (_mSubMenus.ContainsKey(pType)) return;
            var bL = new System.Collections.Generic.Dictionary<string, MBtnode>();
            var isBl = MConfigMgr.Instance.GetMConfigs(pType, out bL);
            if (!isBl) return;
            var subPm = new PopupMenu();
            foreach (var i in bL.Keys)       
            {
                subPm.AddItem(i);
            }
            subPm.Name = pType.ToString();
            subPm.Connect("id_pressed", this, nameof(_OnMenuPressed), new Array
            {
                subPm.Items
            });
            
            AddChild(subPm);
            _mSubMenus[pType] = subPm;
        }

        private void _OnMenuPressed(int i, Array<string> idName)
        {
            GD.Print($"menu item pressed is {i} idName is {idName[i]}");
            EmitSignal(nameof(select_item), idName, i);
        }
    }
}