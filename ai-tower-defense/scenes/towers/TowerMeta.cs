using Microsoft.VisualBasic.FileIO;

namespace AITowerdefense.scenes.tower;

public class TowerMeta {

    private int damage;
    private float range;
    private float fireRate;
    private float projectileSpeed;
    private float cost;

    public TowerMeta(int damage, float range, float fireRate, float projectileSpeed, float cost) {
        this.damage = damage;
        this.range = range;
        this.fireRate = fireRate;
        this.projectileSpeed = projectileSpeed;
        this.cost = cost;
    }

    public int getDamage() {
        return damage;
    }

    public float getRange() {
        return range;
    }

    public float getFireRate() {
        return fireRate;
    }

    public float getProjectileSpeed() {
        return projectileSpeed;
    }

    public float getCost() {
        return cost;
    }
}