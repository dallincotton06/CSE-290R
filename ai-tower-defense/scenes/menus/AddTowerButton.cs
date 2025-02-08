using Godot;

public partial class AddTowerButton : Button {
	private PackedScene tileMapInstance = GD.Load<PackedScene>("res://tiledmaps/test_map.tscn");
	private Node tileMap;
	private TileMapLayer layer1;

	public override void _Ready() {
		Pressed += OnButtonPressed;
		tileMap = tileMapInstance.Instantiate();
		if (tileMap is Node node) {
			layer1 = node.GetChild<TileMapLayer>(0);
		}
	}

	private void OnButtonPressed() {
		QueueFree();
	}

	public override void _ExitTree() {
		base._ExitTree();
		tileMapInstance = null;
		tileMap.Free();
	}
}
