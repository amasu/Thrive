using System;
using Godot;

/// <summary>
///   A widget containing a list of saves
/// </summary>
public class SaveList : ScrollContainer
{
    public override void _Ready()
    {
        var scene = GD.Load<PackedScene>("res://src/saving/SaveListItem.tscn");

        AddChild(scene.Instance());
    }

    public override void _Process(float delta)
    {
    }
}
