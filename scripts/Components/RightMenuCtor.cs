using Dingcodeeditorgd.scripts.Handlers;
using Godot;

namespace Dingcodeeditorgd.scripts.Components
{
    public class RightMenuCtor : Node
    {
        public override void _Input(InputEvent @event)
        {
            base._Input(@event);
            if (@event is InputEventMouseButton mouse &&
                mouse.ButtonIndex == (int) ButtonList.Right &&   
                mouse.Pressed 
            )
            {
                var mpos = mouse.Position;
                
                FileHandlers.CreateFromIdName("test");
                GD.Print($"right press position is {mpos}");
            }
        }
    }
<<<