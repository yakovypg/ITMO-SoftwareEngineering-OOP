using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class LocalFileInteractionProvider : IFileInteractionProvider
{
    public string ReadText(string path)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        return File.ReadAllText(path);
    }

    public bool Exists(string path)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        return File.Exists(path);
    }

    public void Create(string path)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        File.Create(path).Close();
    }

    public void Delete(string path)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        File.Delete(path);
    }

    public void Rename(string path, string newName)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        ArgumentNullException.ThrowIfNull(newName, nameof(newName));

        string destinationPath = ChangeFileNameInPath(path, newName);
        Move(path, destinationPath);
    }

    public string ChangeFileNameInPath(string path, string newName)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        ArgumentNullException.ThrowIfNull(newName, nameof(newName));

        string? name = Path.GetFileName(path);

        if (name == newName)
            return path;

        string? parentDir = Directory.GetParent(path)?.FullName;

        return !string.IsNullOrEmpty(parentDir)
            ? Path.Combine(parentDir, newName)
            : newName;
    }

    public void Move(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath, nameof(sourcePath));
        ArgumentNullException.ThrowIfNull(destinationPath, nameof(destinationPath));

        if (sourcePath != destinationPath)
            File.Move(sourcePath, destinationPath);
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath, nameof(sourcePath));
        ArgumentNullException.ThrowIfNull(destinationPath, nameof(destinationPath));

        File.Copy(sourcePath, destinationPath);
    }
}
