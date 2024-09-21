using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IDirectoryTraversal
{
    IEnumerable<DirectoryTraversalNode> Traversal(int maxDepth = -1);
}
