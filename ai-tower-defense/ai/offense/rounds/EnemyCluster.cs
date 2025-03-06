using System;
using System.Collections.Generic;
using AITowerdefense.scenes.enemies.Components;
using Godot;
using Godot.Collections;

namespace AITowerdefense.ai.offense.rounds;

public class EnemyCluster {

    private PackedScene baseEnemy = GD.Load<PackedScene>("res://scenes/enemies/BaseEnemy.tscn");

    private EnemyMeta meta;
    private int count = 1;
    private float spacing = 0.5f;

    public EnemyCluster(EnemyMeta meta, int count, float spacing) {
        this.meta = meta;
        this.count = count;
        this.spacing = spacing;
    }

    public EnemyCluster(EnemyMeta meta) {
        this.meta = meta;
    }

    public EnemyMeta getMeta() {
        return meta;
    }

    public int getCount() {
        return count;
    }

    public float getSpacing() {
        return spacing;
    }

    public List<(BaseEnemyBody, float)> batch() {
        List<(BaseEnemyBody, float)> batch = new();
        for (int i = 0; i < this.count; i++) {
            BaseEnemyBody clone = baseEnemy.Instantiate<BaseEnemyBody>();
            clone.setMeta(this.meta);
            batch.Add((clone, spacing));
        }
        return batch;
    }
}