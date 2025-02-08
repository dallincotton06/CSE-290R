using Godot;
using System;
using System.Collections.Generic;
using AITowerdefense.scenes.enemies.Components;

public partial class BaseEnemyBody : CharacterBody2D, IDamagable, ICloneable {
	
	private PackedScene instance = GD.Load<PackedScene>("res://scenes/enemies/BaseEnemy.tscn");
	private List<Vector2> TargetPoints = new List<Vector2>(); 
	private int _currentTargetIndex = 0;
	private TestMap mapLayer = null;
	private EnemyMeta meta;
	
	public override void _Ready() {
		base._Ready();
		if (meta == null) {
			QueueFree();
			return;
		}
		if (mapLayer != null) {
			foreach (Vector2I index in mapLayer.getNavigationPoints()) {
				TargetPoints.Add(TestMap.tileToWorld(index, new Vector2(32, 32)));
			}

			Console.WriteLine("[Trgets]: " + getTargetPoints().Count);
		}
	}

	public void plotNavigationData(TestMap tileMapLayer) {
		this.mapLayer = tileMapLayer;
	}

	public List<Vector2> getTargetPoints() {
		return TargetPoints;
	}
	
	public Object Clone() {
		return this.Duplicate();
	}

	public override void _PhysicsProcess(double delta) {
		if (TargetPoints.Count == 0) return;

		Vector2 target = TargetPoints[_currentTargetIndex];
		Vector2 direction = (target - GlobalPosition).Normalized();

		Velocity = direction * meta.getSpeed();
		MoveAndSlide();

		if (GlobalPosition.DistanceTo(target) < 5.0) {
			_currentTargetIndex++;
			if (_currentTargetIndex >= TargetPoints.Count) {
				QueueFree();
			}
		}
	}

	public void damage(int amount) {
		meta.setHealth(meta.getHealth() - amount);
		if (meta.getHealth() <= 0) {
			QueueFree();
		}
	}

	public void setMeta(EnemyMeta meta) {
		this.meta = meta;
	}
	
	public override void _ExitTree() {
		base._ExitTree();
		mapLayer = null;
	}
}
