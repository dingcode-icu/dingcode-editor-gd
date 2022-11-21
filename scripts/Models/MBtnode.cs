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

    public enum BtNodePopenType
    {
        OneChild = 1,  //0001  
        MultiChild = 1<<1, //0010
        OnPar = 1<<2,     //0100
    }
    
    
    public struct MBtnode
    {
        public BtNodePopenType PopenType;
        public BtNodeModelType ModelType;
        public string NickName;
        public string IdName;
        public string Tid;     //unionid in tree model struct 
    }
}