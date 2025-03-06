namespace AITowerdefense.eventbus.events;

public class CurrencyUpdatedEvent : IEvent {
    
    public float currency { get; }

    public CurrencyUpdatedEvent(float currency) {
        this.currency = currency;
    }
    
}