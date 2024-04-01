using System;
using System.Collections.Generic;
using System.IO;
using TriInspector;
using UnityEngine;

public class ReadNote : MonoBehaviour
{
    [SerializeField] List<string> dailyNotemdFiles;
    public string path = "Assets/Script/03_March_2024";
    // Read .md files in a directory.
    [Button]
    public void ReadTextFiles()
    {
        List<string> dailyNotes = GetAllMarkdownFiles(path);
        foreach (string file in dailyNotes)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            try
            {
                var date = DateTime.ParseExact(fileName, "MMM dd, dddd, yyyy", null);
                dailyNotemdFiles.Add(file);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }
    }

    [Button]
    public void ReNameFiles()
    {
        foreach (var noteFile in dailyNotemdFiles)
        {
            // Extract the date part from the file name
            var filePath = Path.GetDirectoryName(noteFile);
            string originalDate = Path.GetFileNameWithoutExtension(noteFile);
            
            // Convert the original date format to DateTime object
            DateTime date = DateTime.ParseExact(originalDate, "MMM dd, dddd, yyyy", null);

            // Format the date to the new format "dd MMMM, dddd, yyyy"
            string newDate = date.ToString("dd MMMM, dddd, yyyy");

            // Create the new file name with the formatted date
            string newFileName = Path.Combine(filePath, newDate + Path.GetExtension(noteFile));

            // Rename the file
            File.Move(noteFile, newFileName);
        }
    }

    [Button]
    public void ResetScript()
    {
        dailyNotemdFiles.Clear();
        
    }

    // Recursive method to get all ".md" files in a directory and its subdirectories
    static List<string> GetAllMarkdownFiles(string directory)
    {
        List<string> mdFiles = new List<string>();

        foreach (string file in Directory.GetFiles(directory, "*.md"))
        {
            mdFiles.Add(file);
        }

        foreach (string subDir in Directory.GetDirectories(directory))
        {
            mdFiles.AddRange(GetAllMarkdownFiles(subDir));
        }

        return mdFiles;
    }

    
}
