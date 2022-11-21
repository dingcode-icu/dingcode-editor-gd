using Godot;
using System;
using Dingcodeeditorgd.scripts.Model;

public class BtnodeGraphNode : GraphNode
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public BtnodeGraphNode(MBtnode mBtnode)
    {
        this.Title = mBtnode.NickName;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Title = "testset";
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
