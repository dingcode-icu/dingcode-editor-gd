using Dingcodeeditorgd.scripts.Components.Inc;
using Dingcodeeditorgd.scripts.Handlers;
using Dingcodeeditorgd.scripts.Model;
using Godot;

namespace Dingcodeeditorgd.scripts.Components
{
    public class RightMenuComp : Node
    {
        
        private Vector2 _curMousePos;


        public override void _Ready()
        {
            base._Ready();
            var global = GetNode<Global>("/root/Global");
            global.InitInnerMBTNodes();
            GD.Print($"global node is right {global}");
        }

        public override void _Input(InputEvent @event)
        {
            base._Input(@event);
            if (@event is InputEventMouseButton mouse &&
                mouse.ButtonIndex == (int) ButtonList.Right &&
                mouse.Pressed
            )
            {
                var mpos = mouse.Position;
                _curMousePos = mpos;
                var uiMenu = ContHandlers.CreateRightMenuPop();
                AddChild(uiMenu);
                uiMenu.Connect("select_item", this, "_onSelectItem");
                uiMenu.Popup_(new Rect2(mpos, uiMenu.RectSize.x, uiMenu.RectSize.y));
            }
        }

        private void _onSelectItem(BtNodeModelType mType, int i)
        {
            var btGraph = ContHandlers.CreateFromIdName("test");
            this.AddChild(btGraph);
            GD.Print($"global position is {_curMousePos}");
            btGraph.SetGlobalPosition(_curMousePos);
            GD.Print($"on select item on {mType}, {i}");    
        }
    }
}