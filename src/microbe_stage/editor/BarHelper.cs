using System.Collections.Generic;
using Godot;

/// <summary>
///   Used to access the color and icon of a bar from the EnergyBalaceInfo dictionary
/// </summary>
public static class BarHelper
{
	private static Dictionary<string, Color> barColors = new Dictionary<string, Color>(){
		{"baseMovement", new Color("#ffbb00")},
		{"flagella", new Color("#ffff00")},
		{"osmoregulation", new Color("#ff00bb")},
		{"oxytoxyProteins", new Color("#ffbbbb")},
		{"nitrogenase", new Color("#ffff00")},
	};

	private static Dictionary<string, string> barIcons = new Dictionary<string, string>(){

	};

	public static Color GetBarColour(string name)
	{
		if (!barColors.ContainsKey(name))
        {
			GD.PrintErr("Bar Colour not found");
			return new Color("#555555");
        }
        else
        {
			return barColors[name];
        }
	}

	public static string GetBarIcons(string name)
	{
		if (!barColors.ContainsKey(name))
        {
			GD.PrintErr("Bar Colour not found");
			return "";
        }
        else
        {
			return barIcons[name];
        }
	}
}

