using Godot;
using System;
using AITowerdefense.scenes.enemies.Components;

public partial class Projectile : Area2D {
	
	const int SPEED = 700;
	private int damage;
	float travelledDistance = 0;

	public override void _Ready() {
		base._Ready();
		this.damage = GD.Load<PackedScene>(GetSceneFilePath()).GetMeta("damage").AsInt32();
		Console.WriteLine(damage);
	}

	public override void _PhysicsProcess(double delta) {
		base._PhysicsProcess(delta);
		Vector2 direction = Vector2.Right.Rotated(GlobalRotation);
		GlobalPosition += direction * SPEED * (float) delta;
		travelledDistance += SPEED * (float) delta;

		if (travelledDistance > 1200) {
			QueueFree();
		}
	}
	
	private void onBodyEntered(Node2D body) {
		if (body is IDamagable damagable) {
			damagable.damage(this.damage);
			QueueFree();
		}
	}
}
