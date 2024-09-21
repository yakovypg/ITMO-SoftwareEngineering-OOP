using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class Message : IEquatable<Message>
{
    public Message(string header, string body, MessagePriority priority = MessagePriority.Normal)
    {
        Id = Guid.NewGuid();
        Priority = priority;
        Header = header ?? throw new ArgumentNullException(nameof(header));
        Body = body ?? throw new ArgumentNullException(nameof(body));
    }

    public Guid Id { get; }
    public string Header { get; }
    public string Body { get; }
    public MessagePriority Priority { get; }

    public bool Equals(Message? other)
    {
        return other is not null && Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Message);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Header, Body, Priority);
    }

    public override string ToString()
    {
        return $"[{Header}] {Body}";
    }
}
