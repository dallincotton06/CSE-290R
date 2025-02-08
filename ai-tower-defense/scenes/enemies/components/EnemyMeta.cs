using System.Collections.Generic;
using System.Diagnostics;
using Godot;

namespace AITowerdefense.scenes.enemies.Components;

public class EnemyMeta {
    private int health;
    private float speed;

    public EnemyMeta(int health, float speed) {
        this.health = health;
        this.speed = speed;
    }

    public int getHealth() {
        return this.health;
    }

    public float getSpeed() {
        return this.speed;
    }

    public void setHealth(int health) {
        this.health = health;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }
}