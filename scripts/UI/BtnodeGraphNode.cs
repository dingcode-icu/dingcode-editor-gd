using Godot;
using Model;

public class BtnodeGraphNode : GraphNode
{
    private MBtnode _mBtnode;
    public BtnodeGraphNode(MBtnode mBtnode)
    {
        _mBtnode = mBtnode;
    }

    public override void _Draw()
    {
        base._Draw();
        GD.Print($"theme color's are {this.Theme.GetColorTypes()}");
    }

    private void _InitSlotCell(BtNodeSlotType sType)
    {
        switch (sType)
        {
            case BtNodeSlotType.RootOutSlot:
                var lChild = new Label();
                lChild.Text = "child";
                lChild.Align = Label.AlignEnum.Right;
                AddChild(lChild);
                SetSlot(0, false, 0, Colors.Red,
                    true, (int) BtNodeSlotType.RootOutSlot, Colors.Gray);
                break;
            case BtNodeSlotType.CompositesSlot:
                var lPar = new Label();
                lPar.Text = "both";
                lPar.Align = Label.AlignEnum.Center;
                AddChild(lPar);
                SetSlot(0, true, (int) BtNodeSlotType.RootOutSlot, Colors.Gray, 
                    true, (int) BtNodeSlotType.CompositesSlot, Colors.Aqua);
                break;
            case BtNodeSlotType.LeafSlot:
                var leaChild = new Label();
                leaChild.Text = "child";
                leaChild.Align = Label.AlignEnum.Right;
                AddChild(leaChild);
                SetSlot(0, true, (int) BtNodeSlotType.CompositesSlot, Colors.Aqua,
                    false, 0, Color.Color8(0, 0, 0, 0));
                break;
            default:
                break;
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //main graph
        Title = _mBtnode.NickName;
        SetSize(new Vector2(120, 100));
        //slot
        _InitSlotCell(_mBtnode.SlotType);
    }
}