using Dingcodeeditorgd.scripts.Model;

namespace Dingcodeeditorgd.scripts.Handlers
{
    public class FileHandlers
    {
        private void CreateGraphNode(ref MBtnode mBtnode)
        {
            var node = new BtnodeGraphNode(mBtnode);    
            
        }

        public static void CreateFromIdName(string idName)
        {
            var model = new MBtnode
            {
                PopenType= BtNodePopenType.OneChild, 
                ModelType = BtNodeModelType.Root,    
                NickName =  idName, 
                IdName = idName, 
                Tid = "1"
            };
        }
    }
}