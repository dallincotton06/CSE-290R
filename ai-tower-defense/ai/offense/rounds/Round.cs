using System.Collections.Generic;

namespace AITowerdefense.ai.offense.rounds;

public class Round {
    
    private List<EnemyCluster> clusters;
    private float clusterSpacing = 0.5f;
    private bool concurrency = false;
    private int roundNumber { get; }

    public Round(List<EnemyCluster> clusters, int roundNumber) {
        this.clusters = clusters;
        this.roundNumber = roundNumber;
    }

    public Round(List<EnemyCluster> clusters, int roundNumber, float clusterSpacing, bool concurrency) {
        this.clusters = clusters;
        this.clusterSpacing = clusterSpacing;
        this.concurrency = concurrency;
        this.roundNumber = roundNumber;
    }

    public List<(BaseEnemyBody, float)> batch() {
        List<(BaseEnemyBody, float)> batch = new();
        foreach (var cluster in clusters) {
            batch.AddRange(cluster.batch());
        }
        return batch;
    }

    public List<EnemyCluster> getClusters() {
        return clusters;
    }

    public float getClusterSpacing() {
        return clusterSpacing;
    }

    public int clustersRemaining() {
        return clusters.Count;
    }

    public bool isConcurrent() {
        return concurrency;
    }
}