using Godot;

namespace AITowerdefense.eventbus.events;

public class BuildSiteClicked : IEvent {

    public Vector2I position { get; }

    public BuildSiteClicked(Vector2I position) {
        this.position = position;
    }
}