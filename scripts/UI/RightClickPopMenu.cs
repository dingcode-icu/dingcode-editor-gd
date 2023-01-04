using System;
using System.Collections.Generic;
using Godot;
using Model;
using Array = Godot.Collections.Array;

namespace UI
{
    public class RightClickPopMenu : PopupMenu
    {
        /// <summary>
        ///     Sigal: emit when select the item to create the btnode graph
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="btName"></param>
        [Signal]
        public delegate void select_item(BtNodeModelType mType, string btName);

        private readonly IDictionary<string, List<string>> _mItemHashMap =
            new Dictionary<string, List<string>>();

        private readonly Godot.Collections.Dictionary<BtNodeModelType, PopupMenu> _mSubMenus =
            new Godot.Collections.Dictionary<BtNodeModelType, PopupMenu>();

        public RightClickPopMenu()
        {
            //main
            foreach (var val in Enum.GetValues(typeof(BtNodeModelType)))
            {
                var pType = val is BtNodeModelType ? (BtNodeModelType)val : BtNodeModelType.Root;
                if (_mSubMenus.ContainsKey(pType)) continue;
                Dictionary<string, MBtnode> bL;
                var isBl = MConfigMgr.Instance.GetMConfigs(pType, out bL);
                if (!isBl) continue;
                _mItemHashMap.Add(val.ToString(), new List<string>());
                _InitSubMenus(pType, bL);
                AddSubmenuItem(val.ToString(), val.ToString());
            }
        }

        private void _InitSubMenus(BtNodeModelType pType, Dictionary<string, MBtnode> bL)
        {
            var subPm = new PopupMenu();
            subPm.Name = pType.ToString();
            foreach (var i in bL.Keys)
            {
                subPm.AddItem(i);
                _mItemHashMap[subPm.Name].Add(i);
            }

            subPm.Connect("id_pressed", this, nameof(_OnMenuPressed), new Array
            {
                subPm.Name
            });

            AddChild(subPm);
            _mSubMenus[pType] = subPm;
        }

        private void _OnMenuPressed(int i, string pType)
        {
            GD.Print($"menu item pressed is {i} idName is {_mItemHashMap[pType][i]}");
            EmitSignal(nameof(select_item), _mItemHashMap[pType][i]);
        }

        // [Signal]
        // delegate void _onMenuPressed();

        private enum HandlerIDs
        {
            // root,  define by enum real value 
        }
    }
}