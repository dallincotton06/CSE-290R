using System;
using System.Collections.Generic;
using AITowerdefense.ai.offense.rounds;
using Godot;

namespace AITowerdefense.tiledmaps.handlers;

public class RoundHandler {
    
    private Round currentRound;
    private List<Round> queue = new();
    private TileMapLayer tileMap;

    public RoundHandler(TileMapLayer tileMap) {
        this.tileMap = tileMap;
    }

    public RoundHandler(TileMapLayer layer, Round round) {
        this.currentRound = round;
        this.tileMap = layer;
    }


    public void addToQueue(Round round) {
        queue.Add(round);
    }

    public void clearQueue() {
        queue.Clear();
    }

    public void batchRound() {
        if (queue.Count == 0) {
            return;
        } else {
            queue[0].batch();
        }
    }

    public async void sendRound() {
        if (queue.Count == 0) {
            return;
        } else {
            foreach ((BaseEnemyBody enemy, float spacing) in queue[0].batch()) {
                enemy.SetPosition(new Vector2(new Random().Next(1000), new Random().Next(1000)));
                enemy.plotNavigationData(tileMap.GetParent<TestMap>());
                tileMap.AddChild(enemy);
                enemy.SetPosition(TestMap.tileToWorld(new Vector2I(0,4), new Vector2(32, 32)));
                await tileMap.ToSignal(tileMap.GetTree().CreateTimer(spacing), "timeout");
            }
        }
    }
    
    public Round getCurrentRound() {
        return currentRound;
    }

    public List<Round> getQueue() {
        return queue;
    }
}