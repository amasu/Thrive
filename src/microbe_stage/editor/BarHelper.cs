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
            case "osmoregulation":
                return new Color("#ffd63e");
            default:
                return new Color ("#444444");
        }
    }

    public static Texture GetBarIcon(string name)
    {
        foreach(var organelle in SimulationParameters.Instance.GetAllOrganelles())
        {
            if (organelle.Name == name)
                return GD.Load<Texture>(organelle.IconPath);
        }
        switch (name)
        {
            case "baseMovement":
                return GD.Load<Texture>("res://assets/textures/gui/bevel/baseMovementIcon.png");
            case "osmoregulation":
                return GD.Load<Texture>("res://assets/textures/gui/bevel/osmoIcon.png");
            default:
                return GD.Load<Texture>("res://assets/textures/gui/logo.png");
        }
    }
}

