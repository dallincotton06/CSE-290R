using Godot;
using System;

public partial class DynamicValueSlider : Control {

	private HSlider slider;
	private RichTextLabel text;
	public override void _Ready() {
		base._Ready();
		slider = GetNode<HSlider>("HSlider");
		text = GetNode<RichTextLabel>("Text");
		text.SetText(slider.MinValue.ToString());
	}

	private void onValueChange(int value) {
		text.SetText(slider.Value.ToString());
	}

	public int getValue() {
		return (int) slider.Value;
	}
}
