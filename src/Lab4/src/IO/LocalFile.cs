using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class LocalFile : DirectoryComponent
{
    public LocalFile(FileInfo info)
        : base(info?.Name ?? throw new ArgumentNullException(nameof(info)), info.FullName)
    {
    }
}
