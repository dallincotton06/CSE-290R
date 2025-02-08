using System;
using AITowerdefense.scenes.tower;
using Godot;

namespace AITowerdefense.tiledmaps.TileActions;
public class BuildTileAction {
    private PackedScene baseTower = GD.Load<PackedScene>("res://scenes/towers/BaseTower.tscn");
        
    public void onCLick(Vector2I position, TileMapLayer mapLayer, TowerMeta meta) {
        Node2D parent = (Node2D) mapLayer.GetParent();
        mapLayer.SetCell(position);
        BaseTower towerToAdd = baseTower.Instantiate<BaseTower>();
        towerToAdd.GlobalPosition = TestMap.tileToWorld(position, new Vector2(128, 128));
        parent.AddChild(towerToAdd, true);
        towerToAdd.initialize(meta);

    }
}