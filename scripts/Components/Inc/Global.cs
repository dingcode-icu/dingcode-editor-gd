using System;
using Godot;
using LitJson;
using Model;

namespace Components.Inc
{
    public class Global : Node
    {

        private static bool _mIsSetupModel = false;
        
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        public void SetupBTNodesConfig()
        {
            if (_mIsSetupModel) return;
            _mIsSetupModel = true;
            //File seems that couldn't work without GDNode
            //so write here and have a test on GD singleton
            var f = new File();
            var fp = f.Open("res://static/inner_btnode.tres", File.ModeFlags.Read);
            var cont = f.GetAsText();
            GD.Print($"read content value is {cont}");
            var ret = JsonMapper.ToObject(cont);
            try
            {
                foreach (var nType in ret.Keys)
                {
                    if (ret.ContainsKey(nType.ToString().ToLower()))
                    {    
                        var tNodes = ret[nType];
                        foreach (var name in tNodes.Keys)
                        {
                            _CheckMBTNodesModel(name, tNodes[name]);
                        }
                    }
                }
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                throw;
            }
            GD.Print($"setup btnodeconfig all is {MConfigMgr.Instance.All()}");
            GD.Print($"setup btnodeconfig ret is {MConfigMgr.Instance.All().Keys}");
        }

        private void _CheckMBTNodesModel(string name, JsonData jsRet)
        {
            try
            {
                var m = new MBtnode();
                m.NickName = jsRet["name"].ToString();
                m.IdName = jsRet["name"].ToString();
                m.ModelType = (BtNodeModelType) Enum.Parse(typeof(BtNodeModelType), jsRet["type"].ToString(), true);
                m.SlotType = MBase.GetSlotType(m.ModelType);
                MConfigMgr.Instance.Add(name,m);
            }
            catch (Exception e)
            {
                GD.PrintErr($"[CheckMBTNodesModel]FAILED check the btnode model->name = {name} \n {e}");
                throw;
            }
        }
    }
}