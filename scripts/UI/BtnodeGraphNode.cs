using Godot;
using Model;

public class BtnodeGraphNode : GraphNode
{
    //整体大小
    private static readonly Vector2 SGraphSize = new Vector2(120, 100);
    private static Color _sTitlteColor;
    private readonly MBtnode _mBtnode;

    public BtnodeGraphNode(MBtnode mBtnode)
    {
        _mBtnode = mBtnode;
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
                    true, (int)BtNodeSlotType.RootOutSlot, Colors.Gray);
                break;
            case BtNodeSlotType.CompositesSlot:
                var lPar = new Label();
                lPar.Text = "both";
                lPar.Align = Label.AlignEnum.Center;
                AddChild(lPar);
                SetSlot(0, true, (int)BtNodeSlotType.RootOutSlot, Colors.Gray,
                    true, (int)BtNodeSlotType.CompositesSlot, Colors.Aqua);
                break;
            case BtNodeSlotType.DecoratorSlot:
                var mPar = new Label();
                mPar.Text = "both";
                mPar.Align = Label.AlignEnum.Center;
                AddChild(mPar);
                SetSlot(0, true, (int)BtNodeSlotType.CompositesSlot, Colors.Gray,
                    true, (int)BtNodeSlotType.CompositesSlot, Colors.Aqua);
                break;
            case BtNodeSlotType.LeafSlot:
                var leaChild = new Label();
                leaChild.Text = "child";
                leaChild.Align = Label.AlignEnum.Right;
                AddChild(leaChild);
                SetSlot(0, true, (int)BtNodeSlotType.CompositesSlot, Colors.Aqua,
                    false, 0, Color.Color8(0, 0, 0, 0));
                break;
        }
    }

    private void ChkThemeGraph()
    {
        SetSize(SGraphSize);
        //title 
        Title = _mBtnode.NickName;
        switch (_mBtnode.ModelType)
        {
            case BtNodeModelType.Action |
                 BtNodeModelType.Condition:
                _sTitlteColor = Colors.Green;
                break;
            case BtNodeModelType.Composite:
                _sTitlteColor = Colors.Fuchsia;
                break;
            case BtNodeModelType.Root:
                _sTitlteColor = Colors.Gray;
                break;
            default:
                _sTitlteColor = Colors.Black;
                break;
        }

        AddColorOverride("title_color", _sTitlteColor);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ChkThemeGraph();
        //slot
        _InitSlotCell(_mBtnode.SlotType);
    }
}