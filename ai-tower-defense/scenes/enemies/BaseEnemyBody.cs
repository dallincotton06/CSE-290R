using Godot;
using System;
using System.Collections.Generic;

public partial class BaseEnemyBody : CharacterBody2D {
	
	private List<Vector2> TargetPoints = new List<Vector2>(); 
	private int _currentTargetIndex = 0;
	private PackedScene testMapInstance = GD.Load<PackedScene>("res://tiledmaps/test_map.tscn");
	private TestMap mapLayer = null;
	[Export] public float Speed = 100.0f;
	
	public override void _Ready() {
		base._Ready();
		if (mapLayer != null) {
			foreach (Vector2I index in mapLayer.getNavigationPoints()) {
				TargetPoints.Add(TestMap.tileToWorld(index));
			}
		}
	}

	public void plotNavigationData(TestMap tileMapLayer) {
		this.mapLayer = tileMapLayer;
	}

	public override void _PhysicsProcess(double delta) {
		if (TargetPoints.Count == 0) return;

		Vector2 target = TargetPoints[_currentTargetIndex];
		Vector2 direction = (target - GlobalPosition).Normalized();

		Velocity = direction * Speed;
		MoveAndSlide();

		if (GlobalPosition.DistanceTo(target) < 5.0) {
			_currentTargetIndex++;
			if (_currentTargetIndex >= TargetPoints.Count) {
				_currentTargetIndex = 0; 
			}
		}
	}
}
