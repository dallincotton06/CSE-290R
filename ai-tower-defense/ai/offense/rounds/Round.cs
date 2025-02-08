using System.Collections.Generic;

namespace AITowerdefense.ai.offense.rounds;

public class Round {
    
    private List<EnemyCluster> clusters;
    private float clusterSpacing = 0.5f;
    private bool concurrency = false;

    public Round(List<EnemyCluster> clusters) {
        this.clusters = clusters;
    }

    public Round(List<EnemyCluster> clusters, float clusterSpacing, bool concurrency) {
        this.clusters = clusters;
        this.clusterSpacing = clusterSpacing;
        this.concurrency = concurrency;
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