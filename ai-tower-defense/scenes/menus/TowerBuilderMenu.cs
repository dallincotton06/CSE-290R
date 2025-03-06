using Godot;
using System;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;
using AITowerdefense.functions;
using AITowerdefense.scenes.tower;
using AITowerdefense.tiledmaps.handlers;

public partial class TowerBuilderMenu : Control {
	
	private Vector2I position;
	private TowerMeta meta;
	private float cost;
	private DynamicValueSlider damageSlider;
	private DynamicValueSlider rangeSlider;
	private DynamicValueSlider fireRateSlider;

	BuildHandler buildHandler;
	
	public override void _Ready() {
		base._Ready();
		damageSlider = GetNode<DynamicValueSlider>("DamageSlider");
		rangeSlider = GetNode<DynamicValueSlider>("RangeSlider");
		fireRateSlider = GetNode<DynamicValueSlider>("FireSpeedSlider");
	}


	public override void _Process(double delta) {
		base._Process(delta);
		RichTextLabel costLabel = GetNode<RichTextLabel>("CostLabel");
		cost = ((float) damageSlider.getValue() / 10) * (rangeSlider.getValue() * 10) * (fireRateSlider.getValue() * 5);
		costLabel.Text = "Cost: $" + cost.ToString();
	}

	public void initialize(Vector2I position, BuildHandler buildHandler) {
		this.position = position;
		this.buildHandler = buildHandler;
	}

	private void onBuildRequest() {
		if (checkForSufficientFunds()) {
			meta = new TowerMeta(damageSlider.getValue(), rangeSlider.getValue(),
				1 / (float) fireRateSlider.getValue(), 300, cost);
		
			EventBus.Instance.Publish(new TowerBuildEvent(meta, position));
			QueueFree();
		}
	}

	private bool checkForSufficientFunds() {
		return CurrencyHandler.value >= cost;
	}
}
