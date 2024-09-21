using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class LocalDirectory : DirectoryComponentComposite
{
    public LocalDirectory(DirectoryInfo info)
        : base(info?.Name ?? throw new ArgumentNullException(nameof(info)), info.FullName)
    {
        foreach (DirectoryInfo subDir in info.GetDirectories())
        {
            AddChild(new LocalDirectory(subDir));
        }

        foreach (FileInfo file in info.GetFiles())
        {
            AddChild(new LocalFile(file));
        }
    }
}
