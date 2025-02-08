using Godot;
using System;
using AITowerdefense.scenes.tower;
using AITowerdefense.tiledmaps.handlers;

public partial class TowerBuilderMenu : Control {
	
	private Vector2I position;
	private TowerMeta meta;

	BuildHandler buildHandler;
	
	public override void _Ready() {
		base._Ready();
	}


	public void initialize(Vector2I position, BuildHandler buildHandler) {
		this.position = position;
		this.buildHandler = buildHandler;
	}

	private void onBuildRequest() {
		meta = new TowerMeta(GetNode<DynamicValueSlider>("DamageSlider").getValue(),
			GetNode<DynamicValueSlider>("RangeSlider").getValue(),
			1 / (float) GetNode<DynamicValueSlider>("FireSpeedSlider").getValue(), 300);
		buildHandler.build(position, meta);
		QueueFree();
	}

	public void queueFreeAll() {
		foreach (Node child in this.GetChildren()) {
			child.QueueFree();
		}
	}
}
