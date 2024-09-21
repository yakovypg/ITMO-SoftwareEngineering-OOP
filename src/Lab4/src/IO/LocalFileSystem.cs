using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class LocalFileSystem : FileSystem
{
    public LocalFileSystem()
    {
    }

    public override string GetAbsolutePath(string path)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        if (Root is null || WorkingDirectory is null)
            throw new FileSystemNotConnectedException();

        bool isPathRooted = Path.IsPathRooted(path);

        while (path.Length > 0 && Path.IsPathRooted(path))
        {
            path = path[1..];
        }

        return !isPathRooted
            ? Path.Combine(WorkingDirectory, path)
            : Path.Combine(Root, path);
    }
}
