using System;
using System.ComponentModel;

namespace Model
{
    public enum BtNodeModelType
    {
        Root,
        Composite,
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
        RootOutSlot = 2, //0001  
        CompositesSlot = 3, //0010
    }


    public struct MBtnode
    {
        public BtNodeSlotType SlotType;
        public BtNodeModelType ModelType;
        public string NickName;
        public string IdName;
        public string Tid; //unionid in tree model struct 
    }

    public class MBase
    {
        public static BtNodeSlotType GetSlotType(BtNodeModelType mType){
            switch (mType)
            {
                case BtNodeModelType.Root:
                    return BtNodeSlotType.RootOutSlot; 
                case BtNodeModelType.Composite:
                    return BtNodeSlotType.CompositesSlot;
                default:
                    return BtNodeSlotType.LeafSlot;
            }
        }
    }
}