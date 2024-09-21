using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class DirectoryTraversalNode
{
    public DirectoryTraversalNode(DirectoryComponent component, int depth)
    {
        Component = component ?? throw new ArgumentNullException(nameof(component));
        Depth = depth;
    }

    public DirectoryComponent Component { get; }
    public int Depth { get; }
}
