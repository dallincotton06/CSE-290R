using System;
using System.Collections.Generic;
using AITowerdefense.ai.offense.rounds;
using AITowerdefense.ai.offense.rounds.presets;
using AITowerdefense.tiledmaps.handlers;

using Godot;


public partial class TestMap : Node2D {
	
	private PackedScene addTowerButton = GD.Load<PackedScene>("res://scenes/popups/add_tower_button.tscn");
	private PackedScene enemy = GD.Load<PackedScene>("res://scenes/enemies/BaseEnemy.tscn");

	private const int TILE_SIZE = 128;
	private readonly Vector2 MAP_SIZE = new Vector2(15, 8);
	private List<TileMapLayer> layers = new();
	private List<Vector2> buildablePositions = new();
	private Node2D navigationLayer = new();
	private Node2D collisionLayer = new();
	private List<Vector2> navigationPoints = new();
	private RoundHandler roundHandler;
	private BuildHandler buildHandler;

	public override void _Ready() {
		base._Ready();
		this.initializeMapLayers();
		this.initializeBuildablePositions();
		this.initializeNavigationData();
		roundHandler = new RoundHandler(layers[0]);
		buildHandler = new BuildHandler(this);

		this.initializeRound();
	}
	private void initializeMapLayers() {
		foreach (var child in this.GetChildren()) {
			if (child is TileMapLayer) {
				layers.Add(child as TileMapLayer);
			} 
			collisionLayer = (Node2D) GetNode("Object Layer 1");
		}
	}

	private void initializeNavigationData() {
		foreach (TileMapLayer layer in layers) {
			foreach (String navigationSet in layer.GetMetaList()) {
				navigationPoints.Add((Vector2I) layer.GetMeta(navigationSet));
			}
		}
	}
	
	public override void _Input(InputEvent @event) {
		var clickedCell = getMouseCell();
		if (isPositionBuildable() && @event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed) {
			buildablePositions.Remove(clickedCell);
			buildHandler.openBuildMenu(clickedCell);
		}
	}

	private bool isPositionBuildable() {
		foreach (Vector2I position in buildablePositions) {
			if (getMouseCell().Equals(position)) {
				return true;
			}
		}
		return false;
	}

	private void initializeBuildablePositions() {
		foreach (var currentLayer in layers) {
			for (int x = 0; MAP_SIZE.X > x; x++) {
				for (int y = 0; MAP_SIZE.Y > y; y++) {
					if (currentLayer.GetCellTileData(new Vector2I(x, y))
							.GetCollisionPolygonsCount(currentLayer.GetIndex()) > 0) {
						buildablePositions.Add(new Vector2(x, y));
					}
				}
			}
		}
	}

	private void initializeRound() {
		roundHandler.addToQueue(new Round1());
		roundHandler.batchRound();
		roundHandler.sendRound();
	}

	private Vector2I getMouseCell() {
		var tileLayer = layers[0];
		return tileLayer.LocalToMap(tileLayer.GetLocalMousePosition());
	}
	
	

	public override void _ExitTree() {
		base._ExitTree();
		addTowerButton = null;
		this.roundHandler.getQueue().Clear();
		this.roundHandler = null;
		foreach (Node child in this.GetChildren()) {
			child.QueueFree();
		}
	}

	public static Vector2 tileToWorld(Vector2I position) {
		return new Vector2(position.X * TILE_SIZE, 
						   position.Y * TILE_SIZE);
	}
	
	public static Vector2 tileToWorld(Vector2I position, Vector2 bounds) {
		return new Vector2(position.X * TILE_SIZE + (TILE_SIZE - bounds.X) / 2, 
						   position.Y * TILE_SIZE + (TILE_SIZE - bounds.Y) / 2);
	}

	public List<Vector2> getNavigationPoints() {
		return navigationPoints;
	}

	public List<TileMapLayer> getLayers() {
		return layers;
	}
	
	
}
