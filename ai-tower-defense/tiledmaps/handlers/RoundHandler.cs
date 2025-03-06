using System;
using System.Collections.Generic;
using AITowerdefense.ai.offense.rounds;
using AITowerdefense.ai.offense.rounds.presets;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;
using Godot;

namespace AITowerdefense.tiledmaps.handlers;

public partial class RoundHandler : Node2D {
	
	private Round currentRound;
	private TestMap tileMap;

	public override void _Ready() {
		base._Ready();
		EventBus.Instance.Subscribe<RoundStartedEvent>(sendRound);
		tileMap = GetParent<TestMap>();
	}

	private async void sendRound(RoundStartedEvent roundFinishedEvent) {
		sendRecievedRound(roundFinishedEvent.round);
		Console.WriteLine(roundFinishedEvent.round.getClusters()[0].getMeta().getHealth()  + " : " +
						  roundFinishedEvent.round.getClusters()[0].getMeta().getSpeed()  + " : " +
						  roundFinishedEvent.round.getClusters()[0].getCount());
	}

	public async void sendRecievedRound(Round round) {
		int sent = 0;
		foreach ((BaseEnemyBody enemy, float spacing) in round.batch()) {
			enemy.plotNavigationData(tileMap);
			tileMap.AddChild(enemy);
			enemy.SetPosition(TestMap.tileToWorld(new Vector2I(0,4), new Vector2(32, 32)));
			await tileMap.ToSignal(tileMap.GetTree().CreateTimer(spacing), "timeout");
			
			sent++;
			if (sent == round.getClusters()[0].getCount()) {
				EventBus.Instance.Publish(new RoundFinishedEvent(round));
			}
		}
	}
	
	
	
	public Round getCurrentRound() {
		return currentRound;
	}
}
