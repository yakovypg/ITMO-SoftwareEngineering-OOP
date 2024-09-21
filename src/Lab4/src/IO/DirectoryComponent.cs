using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public abstract class DirectoryComponent
{
    protected DirectoryComponent(string name, string fullName)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }

    public string Name { get; }
    public string FullName { get; }
}
