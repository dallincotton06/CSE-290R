using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;

namespace AITowerdefense.functions;

public class GameStateHandler {

    public GameStateHandler() {
        EventBus.Instance.Subscribe<HealthUpdatedEvent>(onHealthUpdated);
    }

    public static void onHealthUpdated(HealthUpdatedEvent @event) {
        if (@event.health <= 0) {
            EventBus.Instance.Publish(new GameOverEvent());
        }
    }
}