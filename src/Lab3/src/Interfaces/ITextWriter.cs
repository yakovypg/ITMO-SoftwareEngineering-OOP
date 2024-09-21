namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface ITextWriter
{
    void Clear();
    void Write(string? message);
    void WriteLine(string? message);
}
