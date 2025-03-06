using System;
using System.Collections.Generic;
using Godot;

namespace AITowerdefense.eventbus;

public partial class EventBus : Node {
    private static EventBus instance;
    public static EventBus Instance => instance ??= new EventBus();

    private readonly Dictionary<Type, List<Action<object>>> eventHandlers = new();

    public void Publish<T>(T gameEvent) {
        if (eventHandlers.TryGetValue(typeof(T), out var handlers)) {
            foreach (var handler in handlers) {
                handler.Invoke(gameEvent);
            }
        }
    }

    public void Subscribe<T>(Action<T> handler) {
        var eventType = typeof(T);
        if (!eventHandlers.ContainsKey(eventType))
            eventHandlers[eventType] = new List<Action<object>>();

        eventHandlers[eventType].Add(e => handler((T)e));
    }

    public void Unsubscribe<T>(Action<T> handler) {
        var eventType = typeof(T);
        if (!eventHandlers.ContainsKey(eventType)) return;

        eventHandlers[eventType].RemoveAll(h => h.Equals(handler));
    }
}