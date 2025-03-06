using System;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;
using AITowerdefense.eventbus.events.entity;

namespace AITowerdefense.functions;

public class CurrencyHandler : IHandler {
    
    public static float value = 12000000000;

    public CurrencyHandler() {
        EventBus.Instance.Subscribe<EnemyKilledEvent>(enemyKilled);
        EventBus.Instance.Subscribe<TowerBuildEvent>(towerBuilt);
        EventBus.Instance.Publish(new CurrencyUpdatedEvent(value));
    }

    private void enemyKilled(EnemyKilledEvent @event) {
        value += @event.meta.getEnemyScore();
        EventBus.Instance.Publish(new CurrencyUpdatedEvent(value));
    }

    private void towerBuilt(TowerBuildEvent @event) {
        value -= @event.TowerMeta.getCost();
        EventBus.Instance.Publish(new CurrencyUpdatedEvent(value));
    }
}