using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;

public class OnlyImportantMessagesFilterCreator : ImportanceFilterCreator
{
    public override ImportanceFilter CreateFilter()
    {
        return new ImportanceFilter(m => m.Priority >= MessagePriority.AboveNormal);
    }
}
