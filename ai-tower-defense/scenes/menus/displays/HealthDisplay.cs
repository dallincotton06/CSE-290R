using Godot;
using System;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;

public partial class HealthDisplay : Node2D  {
	public override void _Ready() {
		base._Ready();
		EventBus.Instance.Subscribe<HealthUpdatedEvent>(onHealthUpdate);
	}

	public void onHealthUpdate(HealthUpdatedEvent healthUpdatedEvent) {
		GetNode<RichTextLabel>("TextDisplay").SetText(healthUpdatedEvent.health.ToString());
	}
}
