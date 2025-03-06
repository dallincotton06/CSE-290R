using AITowerdefense.scenes.tower;
using Godot;

namespace AITowerdefense.eventbus.events;

public class TowerBuildEvent {
    public TowerMeta TowerMeta { get; }
    public Vector2I position { get; }

    public TowerBuildEvent(TowerMeta towerMeta, Vector2I position) {
        this.TowerMeta = towerMeta;
        this.position = position;
    }
}