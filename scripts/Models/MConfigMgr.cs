using System.Collections.Generic;
using Godot;

namespace Model
{
    public class MConfigMgr
    {
        private static MConfigMgr _inc;
        private readonly IDictionary<string, MBtnode> _mAllBTNodes = new Dictionary<string, MBtnode>();

        private readonly Dictionary<BtNodeModelType, Dictionary<string, MBtnode>> _mTypeBTNodes =
            new Dictionary<BtNodeModelType, Dictionary<string, MBtnode>>();

        public static MConfigMgr Instance => _inc ?? (_inc = new MConfigMgr());

        /// <summary>
        ///     添加配置管理
        /// </summary>
        /// <param name="idName"></param>
        /// <param name="mNode"></param>
        public void Add(string idName, MBtnode mNode)
        {
            if (_mAllBTNodes.ContainsKey(idName))
            {
                GD.PrintErr($"idName = {idName} is already exists!");
                return;
            }

            _mAllBTNodes.Add(idName, mNode);
            if (!_mTypeBTNodes.ContainsKey(mNode.ModelType))
                _mTypeBTNodes.Add(mNode.ModelType, new Dictionary<string, MBtnode>());
            _mTypeBTNodes[mNode.ModelType].Add(idName, mNode);
        }

        /// <summary>
        ///     直接用idName唯一值获取配置
        /// </summary>
        /// <param name="idName"></param>
        public MBtnode Get(string idName)
        {
            return _mAllBTNodes[idName];
        }

        public IDictionary<string, MBtnode> All()
        {
            return _mAllBTNodes;
        }

        public bool GetMConfigs(BtNodeModelType type, out Dictionary<string, MBtnode> ret)
        {
            return _mTypeBTNodes.TryGetValue(type, out ret);
        }
    }
}