using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public abstract class DirectoryComponentComposite : DirectoryComponent
{
    private readonly List<DirectoryComponent> _children;

    protected DirectoryComponentComposite(string name, string fullName)
        : base(name, fullName)
    {
        _children = new();
    }

    public IReadOnlyList<DirectoryComponent> Children => _children;

    public void AddChild(DirectoryComponent child)
    {
        ArgumentNullException.ThrowIfNull(child, nameof(child));
        _children.Add(child);
    }

    public bool RemoveChild(DirectoryComponent child)
    {
        ArgumentNullException.ThrowIfNull(child, nameof(child));
        return _children.Remove(child);
    }
}
