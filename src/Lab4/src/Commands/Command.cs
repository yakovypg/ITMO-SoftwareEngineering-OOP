using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract class Command : ICommand
{
    protected Command(FileSystem? fileSystem = null)
    {
        FileSystem = fileSystem;
    }

    public FileSystem? FileSystem { get; set; }

    public abstract void Execute();
}
