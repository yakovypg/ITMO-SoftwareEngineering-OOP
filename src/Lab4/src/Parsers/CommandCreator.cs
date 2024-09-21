using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public abstract class CommandCreator
{
    public abstract Command Create(CommandData commandData, FileSystem fileSystem);
}
