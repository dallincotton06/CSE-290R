using System;
using AITowerdefense.eventbus;
using AITowerdefense.eventbus.events;
using AITowerdefense.scenes.tower;
using Godot;

namespace AITowerdefense.tiledmaps.handlers;

public partial class BuildHandler : Node2D {
	private PackedScene buildMenuInstance = GD.Load<PackedScene>("res://scenes/menus/TowerBuilderMenu.tscn");
	private PackedScene baseTower = GD.Load<PackedScene>("res://scenes/towers/BaseTower.tscn");
	private TestMap map;

	public override void _Ready() {
		base._Ready();
		EventBus.Instance.Subscribe<BuildSiteClicked>(openBuildMenu);
		EventBus.Instance.Subscribe<TowerBuildEvent>(build);
		map = GetParent<TestMap>();
	}

	private void openBuildMenu(BuildSiteClicked buildEvent) {
		TowerBuilderMenu buildMenu = buildMenuInstance.Instantiate<TowerBuilderMenu>();
		buildMenu.SetPosition(TestMap.tileToWorld(new Vector2I(buildEvent.position.X - 2, buildEvent.position.Y - 2), buildMenu.Size));
		buildMenu.initialize(buildEvent.position, this);
		map.AddChild(buildMenu);
	}

	public void build(TowerBuildEvent buildEvent) {
		Console.WriteLine("BUILDING");
		TileMapLayer mapLayer = map.getLayers()[0];
		mapLayer.SetCell(buildEvent.position);
		BaseTower towerToAdd = baseTower.Instantiate<BaseTower>();
		towerToAdd.GlobalPosition = TestMap.tileToWorld(buildEvent.position, new Vector2(128, 128));
		map.AddChild(towerToAdd, true);
		towerToAdd.initialize(buildEvent.TowerMeta);
	}
}
