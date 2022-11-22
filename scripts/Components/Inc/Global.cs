using System;
using Godot;
using Godot.Collections;
using LitJson;

namespace Dingcodeeditorgd.scripts.Components.Inc
{
    struct InnerBTNodesConfig
    {
        public JsonType action;
        
    }
    
    public class Global : Node
    {

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        public void InitInnerMBTNodes()
        {
            //File seems that couldn't work without GDNode
            //so write here and have a test on GD singleton
            var f = new File();
            var fp = f.Open("res://static/inner_btnode.tres", File.ModeFlags.Read);
            var cont = f.GetAsText();
            GD.Print($"read content value is {cont}");
            var ret = JsonMapper.ToObject(cont);
            try
            {
                var tNodes = ret["action"];
                foreach (var name in tNodes)
                {
                    GD.Print($"node's name is  {name}");
                }

            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void CheckMBTNodesModel(string name, JSONParseResult jsRet)
        {
            GD.Print($"bt key is {name} {jsRet}");
            var jsRoot = jsRet.Result as Dictionary<string, string>;
            try
            {
                // jsRoot[""]
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
    }
}
