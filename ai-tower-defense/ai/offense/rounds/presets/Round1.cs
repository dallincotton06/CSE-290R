using System.Collections.Generic;
using System.Linq;
using AITowerdefense.scenes.enemies.Components;
using Godot;

namespace AITowerdefense.ai.offense.rounds.presets;

public class Round1 : Round {
    
    private static PackedScene enemyScene = GD.Load<PackedScene>("res://scenes/enemies/BaseEnemy.tscn");
    
    public Round1() : base(new EnemyCluster[] {
        new EnemyCluster(new EnemyMeta(3500000, 40), 1, 0.5f),
        new EnemyCluster(new EnemyMeta(100, 600), 10, 0.05f)
    }.ToList()) {
        
    }
} 