using Godot;

namespace Components
{
    public class ContComp : GraphEdit
    {
        public override void _Ready()
        {
            base._Ready();
            Connect("connection_request", this, nameof(_OnSlotConnectRequest));
        }

        private void _OnSlotConnectRequest( string from, int fromSlot, string to, int toSlot)
        {
            ConnectNode(from, fromSlot, to, toSlot);
        }
    }
}