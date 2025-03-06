using AITowerdefense.scenes.enemies.Components;

namespace AITowerdefense.eventbus.events.entity;

public class EntityExitedEvent : IEvent {
    
    public EnemyMeta meta { get; }

    public EntityExitedEvent(EnemyMeta meta) {
        this.meta = meta;
    }
    
}