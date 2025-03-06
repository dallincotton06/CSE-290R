using System;
using System.Reflection.Emit;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;
using AITowerdefense.eventbus.events.entity;

namespace AITowerdefense.functions;

public class HealthHandler : IHandler {
    
    public static int value = 100;

    public HealthHandler() {
        EventBus.Instance.Subscribe<EntityExitedEvent>(enemyExited);
        EventBus.Instance.Publish(new HealthUpdatedEvent(value));
    }

    private void enemyExited(EntityExitedEvent entityExitedEvent) {
        value -= (int) Math.Clamp(entityExitedEvent.meta.getEnemyScore() / 1000, 1, 100);
        EventBus.Instance.Publish(new HealthUpdatedEvent(value));
    }
}