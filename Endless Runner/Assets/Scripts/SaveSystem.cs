/*
 * Code Artifact Name: SaveSystem
 * Description: Provides functionality to save and load game data in JSON format.
 * Programmer's Name: [Your Name]
 * Date Created: [Original creation date]
 * Revision History:
 *   - [Date 1]: Initial creation of the script by [Author's Name].
 * Preconditions:
 *   - Save folder must be accessible within the device's file system.
 * Acceptable Input Values:
 *   - Filename must be a valid string.
 *   - Data to save must be a valid JSON string.
 * Unacceptable Input Values:
 *   - Null or empty strings for filename or data.
 * Postconditions:
 *   - Data is saved to a file or loaded from an existing file.
 * Return Values:
 *   - Save: None.
 *   - Load: Returns the JSON string if the file exists; otherwise, null.
 * Error and Exception Conditions:
 *   - IOException if file access fails.
 * Side Effects:
 *   - Creates new files or overwrites existing ones.
 * Invariants:
 *   - File extension is always `.json`.
 * Known Faults:
 *   - Does not handle file access permissions or corruption issues.
 */

using UnityEngine;
using System.IO;

public static class SaveSystem
{
    // Directory where save files are stored
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/Saves/";

    // File extension for save files
    public static readonly string FILE_EXT = ".json";

    // Saves a JSON string to a file
    public static void Save(string filename, string dataToSave)
    {
        // Ensure the save folder exists
        if (!Directory.Exists(SAVE_FOLDER)) 
        {
            Directory.CreateDirectory(SAVE_FOLDER); // Create the folder if it doesn't exist
        }

        // Write the JSON string to the specified file
        File.WriteAllText(SAVE_FOLDER + filename + FILE_EXT, dataToSave); 
    }

    // Loads a JSON string from a file
    public static string Load(string filename)
    {
        string fileLoc = SAVE_FOLDER + filename + FILE_EXT; // Construct the file path

        // Check if the file exists at the specified location
        if (File.Exists(fileLoc))
        {
            string loadedData = File.ReadAllText(fileLoc); // Read the file's content
            return loadedData; // Return the loaded data
        }
        else
        {
            return null; // Return null if the file doesn't exist
        }
    }
}
