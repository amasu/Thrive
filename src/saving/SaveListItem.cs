using System;
using System.Globalization;
using System.Threading.Tasks;
using Godot;

/// <summary>
///   An item in the saves list. This is a class to handle loading its data from the file
/// </summary>
public class SaveListItem : HBoxContainer
{
    [Export]
    public NodePath SaveNamePath;

    [Export]
    public NodePath ScreenshotPath;

    [Export]
    public NodePath VersionPath;

    [Export]
    public NodePath TypePath;

    [Export]
    public NodePath CreatedAtPath;

    [Export]
    public NodePath CreatedByPath;

    [Export]
    public NodePath CreatedOnPlatformPath;

    [Export]
    public NodePath DescriptionPath;

    private Label saveNameLabel;
    private TextureRect screenshot;
    private Label version;
    private Label type;
    private Label createdAt;
    private Label createdBy;
    private Label createdOnPlatform;
    private Label description;

    private string saveName;

    private bool loadingData;
    private Task<Save> saveInfoLoadTask;

    public string SaveName
    {
        get
        {
            return saveName;
        }
        set
        {
            if (value == saveName)
                return;

            saveName = value;
            LoadSaveData();
            UpdateName();
        }
    }

    public override void _Ready()
    {
        saveNameLabel = GetNode<Label>(SaveNamePath);
        screenshot = GetNode<TextureRect>(ScreenshotPath);
        version = GetNode<Label>(VersionPath);
        type = GetNode<Label>(TypePath);
        createdAt = GetNode<Label>(CreatedAtPath);
        createdBy = GetNode<Label>(CreatedByPath);
        createdOnPlatform = GetNode<Label>(CreatedOnPlatformPath);
        description = GetNode<Label>(DescriptionPath);

        UpdateName();
    }

    public override void _Process(float delta)
    {
        if (!loadingData)
            return;

        if (!saveInfoLoadTask.IsCompleted)
            return;

        var save = saveInfoLoadTask.Result;
        saveInfoLoadTask.Dispose();
        saveInfoLoadTask = null;

        // Screenshot
        var texture = new ImageTexture();
        texture.CreateFromImage(save.Screenshot);

        screenshot.Texture = texture;

        // General info
        version.Text = save.Info.ThriveVersion;
        type.Text = save.Info.Type.ToString();
        createdAt.Text = save.Info.CreatedAt.ToString("G", CultureInfo.CurrentCulture);
        createdBy.Text = save.Info.Creator;
        createdOnPlatform.Text = save.Info.Platform.ToString();
        description.Text = save.Info.Description;

        loadingData = false;
    }

    private void LoadSaveData()
    {
        loadingData = true;

        saveInfoLoadTask = new Task<Save>(() => Save.LoadInfoAndScreenshotFromSave(saveName));
        TaskExecutor.Instance.AddTask(saveInfoLoadTask);
    }

    private void UpdateName()
    {
        if (saveNameLabel != null)
            saveNameLabel.Text = saveName;
    }
}
