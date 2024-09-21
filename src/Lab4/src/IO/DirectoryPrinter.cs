using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class DirectoryPrinter : IDirectoryPrinter
{
    public void Print(
        ITextWriter output,
        IDirectoryTraversal traversal,
        PrintDecorations decorations,
        int maxDepth)
    {
        ArgumentNullException.ThrowIfNull(output, nameof(output));
        ArgumentNullException.ThrowIfNull(traversal, nameof(traversal));
        ArgumentNullException.ThrowIfNull(decorations, nameof(decorations));

        string marginMark = decorations.MarginMark;

        foreach (DirectoryTraversalNode node in traversal.Traversal(maxDepth))
        {
            bool isDirectory = node.Component is DirectoryComponentComposite;
            string componentMark = isDirectory ? decorations.FolderMark : decorations.FileMark;

            string margin = new StringBuilder(marginMark.Length * node.Depth)
                .AppendJoin(marginMark, new string[node.Depth + 1])
                .ToString();

            output.WriteLine($"{margin}{componentMark}{node.Component.Name}:");
        }
    }
}
