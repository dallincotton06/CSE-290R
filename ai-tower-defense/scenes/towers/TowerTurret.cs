using Godot;
using System;

public partial class TowerTurret : Area2D {
	
	private PackedScene projectileInstance = GD.Load<PackedScene>("res://scenes/projectiles/Projectile.tscn");
	private BaseTower tower;

	public override void _PhysicsProcess(double delta) {
		base._PhysicsProcess(delta);
		var enemies_in_range = GetOverlappingBodies();
		if (enemies_in_range.Count > 0) {
			Node2D targetEnemy = enemies_in_range[0];
			Vector2 pos = targetEnemy.GlobalPosition;
			GetNode<Sprite2D>("Tower-turrett").LookAt(pos);
		}
	}
	private void shoot() {
		Marker2D shootingPoint = GetNode<Marker2D>($"%ShootingPoint");
		Projectile projectile = (Projectile) projectileInstance.Instantiate();

		this.AddChild(projectile);
		projectile.GlobalPosition = shootingPoint.GlobalPosition;
		projectile.GlobalRotation = shootingPoint.GlobalRotation;

	}
	public void onTimerTimeup() {
		this.shoot();
	}

	public void initialize(BaseTower tower) {
		this.tower = tower;
		GetNode<Timer>("../Reload").SetWaitTime(tower.getTowerMeta().getFireRate());
		GetNode<CollisionShape2D>("Range").Scale = new Vector2(this.tower.getTowerMeta().getRange(),
																	   this.tower.getTowerMeta().getRange());
		this.projectileInstance.SetMeta("damage", (int) this.tower.getTowerMeta().getDamage());
	}

	public override void _ExitTree() {
		base._ExitTree();
		projectileInstance.Free();
	}
}
