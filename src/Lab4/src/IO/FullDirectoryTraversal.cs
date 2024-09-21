using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class FullDirectoryTraversal : IDirectoryTraversal
{
    private readonly DirectoryComponentComposite _directory;

    public FullDirectoryTraversal(DirectoryComponentComposite directory)
    {
        _directory = directory ?? throw new ArgumentNullException(nameof(directory));
    }

    public IEnumerable<DirectoryTraversalNode> Traversal(int maxDepth = -1)
    {
        return Traversal(_directory, 0, maxDepth);
    }

    private static IEnumerable<DirectoryTraversalNode> Traversal(
        DirectoryComponentComposite directory,
        int currDepth,
        int maxDepth)
    {
        ArgumentNullException.ThrowIfNull(directory, nameof(directory));

        yield return new DirectoryTraversalNode(directory, currDepth);

        if (maxDepth >= 0 && currDepth > maxDepth)
            yield break;

        foreach (DirectoryComponent component in directory.Children)
        {
            if (component is DirectoryComponentComposite subdirectory)
            {
                foreach (DirectoryTraversalNode node in Traversal(subdirectory, currDepth + 1, maxDepth))
                {
                    yield return node;
                }
            }
            else
            {
                yield return new DirectoryTraversalNode(component, currDepth + 1);
            }
        }
    }
}
