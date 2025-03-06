using AITowerdefense.ai.offense.rounds;

namespace AITowerdefense.eventbus.events;

public class RoundFinishedEvent : IEvent {
    
    public Round round { get; }

    public RoundFinishedEvent(Round round) {
        this.round = round;
    }
}