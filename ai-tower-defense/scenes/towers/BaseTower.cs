using Godot;
using System;
using System.Dynamic;
using AITowerdefense.scenes.tower;

public partial class BaseTower : Sprite2D {

	private TowerMeta meta;
	private TowerTurret turret;

	public override void _Ready() {
		base._Ready();
		turret = GetNode<TowerTurret>("TowerTurret");
	}

	public override void _PhysicsProcess(double delta) {
		
	}

	public override void _ExitTree() {
		base._ExitTree();
	}

	public void initialize(TowerMeta meta) {
		this.meta = meta;
		turret.initialize(this);
	}

	public TowerMeta getTowerMeta() {
		return this.meta;
	}
}
