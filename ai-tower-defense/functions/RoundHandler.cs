using System;
using AITowerdefense.ai.offense.rounds;
using AITowerdefense.ai.offense.sender;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;
using Godot;

namespace AITowerdefense.functions;

public partial class RoundHandler : Node2D {
	
	private int roundNumber = 100;
	private float diffucultyScaling = 1f;
	private Round round;
	private bool active = false;
	private SentientRoundCreator roundCreator = new();

	public RoundHandler() {
		EventBus.Instance.Subscribe<RoundStartedEvent>(onRoundStarted);
		EventBus.Instance.Subscribe<RoundFinishedEvent>(onRoundFinished);
		round = roundCreator.createRound(1, diffucultyScaling);
	}

	private void onRoundStarted(RoundStartedEvent @event) {
		active = true;
	}

	private void onRoundFinished(RoundFinishedEvent @event) {
		roundNumber++;
		round = roundCreator.createRound(roundNumber, diffucultyScaling);
		active = false;
	}

	public async override void _Input(InputEvent @event) {
 		if (@event is InputEventKey keyEvent && keyEvent.Keycode == Key.Space && active == false) {
			EventBus.Instance.Publish(new RoundStartedEvent(this.round, roundNumber));
		}
	}
}
