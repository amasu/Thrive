using System;
using System.Collections.Generic;
using Godot;

/// <summary>
///   Class for managing the save files on disk
/// </summary>
public class SaveManager
{
    public static void RemoveExcessSaves()
    {
        RemoveExcessAutoSaves();
        RemoveExcessQuickSaves();
    }

    public static void RemoveExcessAutoSaves()
    {
        throw new System.NotImplementedException();
    }

    public static void RemoveExcessQuickSaves()
    {
        // throw new System.NotImplementedException();
    }

    /// <summary>
    ///   Returns a list of all saves
    /// </summary>
    /// <returns>The list of save names</returns>
    public static List<string> CreateListOfSaves()
    {
        var result = new List<string>();

        using (var directory = new Directory())
        {
            if (!directory.DirExists(Constants.SAVE_FOLDER))
                return result;

            directory.Open(Constants.SAVE_FOLDER);
            directory.ListDirBegin(true, true);

            while (true)
            {
                var filename = directory.GetNext();

                if (string.IsNullOrEmpty(filename))
                    break;

                if (!filename.EndsWith(Constants.SAVE_EXTENSION, StringComparison.Ordinal))
                    continue;

                result.Add(filename);
            }

            directory.ListDirEnd();
        }

        return result;
    }

    /// <summary>
    ///   Refreshes the list of saves this manager knows about
    /// </summary>
    public void RefreshSavesList()
    {
        throw new System.NotImplementedException();
    }
}
