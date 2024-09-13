using System;
using System.IO;

namespace Donut.Filters.Files;
public interface IFileWriter
{
    void WriteToFile(string content, string filePath);
    void CreateFile(string filePath);
    void CreateFolder(string folderPath);
}

public class FileWriter : IFileWriter
{
    public void WriteToFile(string content, string filePath)
    {
        if (content is null)
            throw new ArgumentNullException(nameof(content), "Content cannot be null.");

        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath), "File path cannot be null.");

        try
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"Content successfully written to {filePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            throw;
        }
    }

    public void CreateFile(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath), "File path cannot be null.");

        try
        {
            // Create the directory if it doesn't exist
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Create the file
            using (FileStream fs = File.Create(filePath))
            {
                Console.WriteLine($"File created successfully: {filePath}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while creating the file: {ex.Message}");
            throw;
        }
    }

    public void CreateFolder(string folderPath)
    {
        if (folderPath is null)
            throw new ArgumentNullException(nameof(folderPath), "Folder path cannot be null.");

        try
        {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"Folder created successfully: {folderPath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while creating the folder: {ex.Message}");
            throw;
        }
    }
}