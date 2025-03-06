using System;
using System.Collections.Generic;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;
using AITowerdefense.scenes.tower;
using Godot;

namespace AITowerdefense.ai.offense.sender;

public class TowerReaderHandler {

    public static List<TowerMeta> towers { get; } = new();

    public TowerReaderHandler() {
        EventBus.Instance.Subscribe<TowerBuildEvent>(addTower);
    }
    
    private void addTower(TowerBuildEvent towerBuildEvent) {
        Console.WriteLine("Adding Tower:" + towerBuildEvent.TowerMeta);
        towers.Add(towerBuildEvent.TowerMeta);
    }
}