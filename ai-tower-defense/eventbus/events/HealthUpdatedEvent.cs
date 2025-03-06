namespace AITowerdefense.eventbus.events;

public class HealthUpdatedEvent : IEvent {
    public int health { get; }

    public HealthUpdatedEvent(int health) {
        this.health = health;
    }
}