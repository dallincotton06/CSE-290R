using Godot;
using System;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;

public partial class CurrencyDisplay : Node2D {
	
	public override void _Ready() {
		base._Ready();
		EventBus.Instance.Subscribe<CurrencyUpdatedEvent>(updateDisplay);
	}

	private void updateDisplay(CurrencyUpdatedEvent currencyUpdatedEvent) {
		GetNode<RichTextLabel>("TextDisplay").SetText(currencyUpdatedEvent.currency.ToString());
	}
}
