using Godot;
using System;
using Dingcodeeditorgd.scripts.Model;

public class BtnodeGraphNode : GraphNode
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private MBtnode _mBtnode;

    public BtnodeGraphNode(MBtnode mBtnode)
    {
        _mBtnode = mBtnode;
    }


    private void _initSlotDisplay(BtNodeSlotType sType)
    {
        switch (sType)
        {
            case BtNodeSlotType.RootOutSlot:
                var lChild = new Label();
                lChild.Text = "child";
                lChild.Align = Label.AlignEnum.Right;
                AddChild(lChild);
                SetSlot(0, false, 0, Colors.Red,
                    true, (int) BtNodeSlotType.RootOutSlot, Color.Color8(0, 0, 0, 0));
                break;
            case BtNodeSlotType.CompositesSlot:
                var lPar = new Label();
                lPar.Text = "both";
                lPar.Align = Label.AlignEnum.Center;
                AddChild(lPar);
                SetSlot(0, true, (int) BtNodeSlotType.RootOutSlot, Colors.Red, true,
                    (int) BtNodeSlotType.CompositesSlot, Colors.Aqua);
                break;
            case BtNodeSlotType.LeafSlot:
                var leaChild = new Label();
                leaChild.Text = "child";
                leaChild.Align = Label.AlignEnum.Right;
                AddChild(leaChild);
                SetSlot(0, true, 0, Colors.Aqua,
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
        _initSlotDisplay(_mBtnode.SlotType);
    }
}