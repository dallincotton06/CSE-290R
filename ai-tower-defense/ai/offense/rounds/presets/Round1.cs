using System;
using System.Collections.Generic;
using System.Linq;
using AITowerdefense.ai.offense.sender;
using AITowerdefense.scenes.enemies.Components;
using Godot;

namespace AITowerdefense.ai.offense.rounds.presets;

public class Round1 : Round {
    
    private static PackedScene enemyScene = GD.Load<PackedScene>("res://scenes/enemies/BaseEnemy.tscn");

    private static EnemyHealthModel.ConsoleApp.EnemyHealthModel.ModelInput sampleData = new() {
        Average_Damage = 0.9F,
        Average_Range = 0.1F,
        Average_Fire_Rate = 0.1F,
        Max_Damage = 0.95F
    };
    
    private static EnemySpeedModel.ConsoleApp.EnemySpeedModel.ModelInput sampleData2 = new() {
        Average_Damage = 0.9F,
        Average_Range = 0.1F,
        Average_Fire_Rate = 0.1F,
        Max_Damage = 0.95F
    };
    
    private static EnemyCountModel.ConsoleApp.EnemyCountModel.ModelInput sampleData3 = new() {
        Average_Damage = 0.9F,
        Average_Range = 0.1F,
        Average_Fire_Rate = 0.1F,
        Max_Damage = 0.95F
    };
    
    
    
    private static float health = (float) EnemyHealthModel.ConsoleApp.EnemyHealthModel.Predict(sampleData).Score;
    private static float speed = (float) EnemySpeedModel.ConsoleApp.EnemySpeedModel.Predict(sampleData2).Score;
    private static float count = (float) EnemyCountModel.ConsoleApp.EnemyCountModel.Predict(sampleData3).Score;

    public Round1() : base(new EnemyCluster[] {
        new EnemyCluster(new EnemyMeta((int) (health *  100), Math.Clamp(speed * 1000, 100, 800)), (int) Math.Clamp(count * 1000, 1, 100000), 0.05f),
    }.ToList(), 1) {
        Console.WriteLine((int) (health * 100) + " : " + Math.Clamp(speed * 1000, 25, 800) + " : " + Math.Clamp(count * 1000, 1, 100000));
    } 
} 