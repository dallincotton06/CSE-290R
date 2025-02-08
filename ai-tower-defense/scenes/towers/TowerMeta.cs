using Microsoft.VisualBasic.FileIO;

namespace AITowerdefense.scenes.tower;

public class TowerMeta {

    private int damage;
    private float range;
    private float fireRate;
    private float projectileSpeed;

    public TowerMeta(int damage, float range, float fireRate, float projectileSpeed) {
        this.damage = damage;
        this.range = range;
        this.fireRate = fireRate;
        this.projectileSpeed = projectileSpeed;
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
}