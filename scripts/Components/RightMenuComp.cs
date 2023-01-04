using Components.Inc;
using Godot;
using Handlers;
using Model;

namespace Components
{
    public class RightMenuComp : Node
    {
        private Vector2 _curMousePos;


        public override void _Ready()
        {
            base._Ready();
            var G = GetNode<Global>("/root/Global");
            G.SetupBTNodesConfig();
        }

        public override void _Input(InputEvent @event)
        {
            base._Input(@event);
            if (@event is InputEventMouseButton mouse &&
                mouse.ButtonIndex == (int)ButtonList.Right &&
                mouse.Pressed
               )
            {
                var mpos = mouse.Position;
                _curMousePos = mpos;
                var uiMenu = ContHandlers.CreateRightMenuPop();
                AddChild(uiMenu);
                uiMenu.Connect("select_item", this, nameof(_onSelectItem));
                uiMenu.Popup_(new Rect2(mpos, uiMenu.RectSize.x, uiMenu.RectSize.y));
            }
        }

        private void _onSelectItem(string idName)
        {
            var m = MConfigMgr.Instance.Get(idName);
            var btGraph = ContHandlers.CreateFromIdName(m);
            GetParent().AddChild(btGraph);
            GD.Print($"global position is {_curMousePos}");
            btGraph.SetPosition(_curMousePos);
        }
    }
}