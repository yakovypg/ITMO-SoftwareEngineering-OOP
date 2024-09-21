using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class ImportanceFilter
{
    private readonly Predicate<Message> _predicate;

    public ImportanceFilter(Predicate<Message> predicate)
    {
        _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
    }

    public bool Accept(Message message)
    {
        return _predicate(message);
    }
}
