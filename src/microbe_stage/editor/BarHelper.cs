using Godot;

/// <summary>
///   Used to access the color and icon of a bar from the EnergyBalaceInfo dictionary
/// </summary>
public static class BarHelper
{
	public static Color GetBarColour(string name, char type)
	{
		foreach(var organelle in SimulationParameters.Instance.GetAllOrganelles())
		{
			if (organelle.Name == name)
			{
				if (type == 'p')
				{
					return new Color(organelle.ProductionColour);
				}
				else if (type == 'c')
				{
					return new Color(organelle.ConsumptionColour);
				}
				else
				{
					return new Color ("#444444");
				}
			}
		}
		switch (name)
		{
			case "baseMovement":
				return new Color("#ff5524");
			case "flagella":
				return new Color("#ff9721");
			case "osmoregulation":
				return new Color("#ffd63e");
			default:
				return new Color ("#444444");
		}
	}

	public static string GetBarIcons(string name)
	{
		switch (name)
		{
			default:
				return "";
		}
	}
}

