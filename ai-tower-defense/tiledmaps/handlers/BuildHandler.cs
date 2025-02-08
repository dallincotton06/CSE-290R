using AITowerdefense.scenes.tower;
using AITowerdefense.tiledmaps.TileActions;
using Godot;

namespace AITowerdefense.tiledmaps.handlers;

public class BuildHandler {
    private PackedScene buildMenuInstance = GD.Load<PackedScene>("res://scenes/menus/TowerBuilderMenu.tscn");
    private BuildTileAction action = new BuildTileAction();
    private TestMap map;

    public BuildHandler(TestMap map) {
        this.map = map;
    }

    public void openBuildMenu(Vector2I position) {
        TowerBuilderMenu buildMenu = buildMenuInstance.Instantiate<TowerBuilderMenu>();
        buildMenu.SetPosition(TestMap.tileToWorld(new Vector2I(position.X - 2, position.Y - 2), buildMenu.Size));
        buildMenu.initialize(position, this);
        map.AddChild(buildMenu);
    }

    public void build(Vector2I position, TowerMeta meta) {
        action.onCLick(position, map.getLayers()[0], meta);
    }
}