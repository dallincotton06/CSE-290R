using System;
using AITowerdefense.tiledmaps.TileActions.Actions;
using Godot;

namespace AITowerdefense.tiledmaps.TileActions;
public class BuildTileAction : ITileClickable {
    private PackedScene baseTower = GD.Load<PackedScene>("res://scenes/towers/BaseTower.tscn");
        
    public void onCLick(Vector2I position, TileMapLayer mapLayer) {
        Node2D parent = (Node2D) mapLayer.GetParent();
        mapLayer.SetCell(position);
        Node2D towerToAdd = ((Node2D) baseTower.Instantiate());
        towerToAdd.SetPosition(TestMap.tileToWorld(position));
        parent.AddChild(towerToAdd, true);
    }
}