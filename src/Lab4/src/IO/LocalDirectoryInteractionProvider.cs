using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class LocalDirectoryInteractionProvider : IDirectoryInteractionProvider
{
    public bool Exists(string path)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        return Directory.Exists(path);
    }

    public DirectoryComponentComposite GetDirectory(string path)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        return new LocalDirectory(new DirectoryInfo(path));
    }
}
