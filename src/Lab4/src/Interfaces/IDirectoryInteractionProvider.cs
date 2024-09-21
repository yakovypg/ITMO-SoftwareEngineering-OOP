using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IDirectoryInteractionProvider
{
    bool Exists(string path);
    DirectoryComponentComposite GetDirectory(string path);
}
