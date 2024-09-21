using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IDirectoryPrinter
{
    void Print(
        ITextWriter output,
        IDirectoryTraversal traversal,
        PrintDecorations decorations,
        int maxDepth);
}
