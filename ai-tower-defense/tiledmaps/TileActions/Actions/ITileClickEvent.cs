using Godot;

namespace AITowerdefense.tiledmaps.TileActions.Actions;

public interface ITileClickable : ITileEvent {

    void onCLick(Vector2I position, TileMapLayer mapLayer);
    
}