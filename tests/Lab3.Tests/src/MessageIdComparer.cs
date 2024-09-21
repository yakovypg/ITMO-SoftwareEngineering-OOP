using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageIdComparer : IComparer<Message>
{
    public int Compare(Message? x, Message? y)
    {
        if (x is null && y is null)
            return 0;

        if (x is null)
            return -1;

        if (y is null)
            return 1;

        return x.Id.CompareTo(y.Id);
    }
}
