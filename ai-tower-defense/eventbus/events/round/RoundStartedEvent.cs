using AITowerdefense.ai.offense.rounds;

namespace AITowerdefense.eventbus.events;

public class RoundStartedEvent {

    public Round round { get; }
    public int roundNumber { get; }

    public RoundStartedEvent(Round round, int roundNumber) {
        this.round = round;
        this.roundNumber = roundNumber;
    }

}