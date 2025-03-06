using AITowerdefense.scenes.enemies.Components;

namespace AITowerdefense.eventbus.events.entity;

public class EnemyKilledEvent {

    public EnemyMeta meta { get; }

    public EnemyKilledEvent(EnemyMeta meta) {
        this.meta = meta;
    }
}