using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public abstract class CommandExtractorFactory
{
    public abstract ICommandExtractor CreateSimpleCommandExtractor(CommandData commandData);
    public abstract ICommandExtractor CreateComplexCommandExtractor(CommandData commandData);
}
