using System;

namespace Dingcodeeditorgd.scripts.Model
{
    public enum BtNodeModelType
    {
        Root,
        Composites,
        Decorator,
        Condition,
        Action,
        Const
    }

    public enum ModelBase
    {
        Parent = 1,
        Child = 1 << 2,
    }

    public enum BtNodeSlotType
    {
        LeafSlot = 1, //0100
        RootOutSlot = 1 << 1, //0001  
        CompositesSlot = 1 << 2, //0010
    }


    public struct MBtnode
    {
        public BtNodeSlotType SlotType;
        public BtNodeModelType ModelType;
        public string NickName;
        public string IdName;
        public string Tid; //unionid in tree model struct 
    }
}