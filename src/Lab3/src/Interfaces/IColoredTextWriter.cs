using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IColoredTextWriter : ITextWriter
{
    ConsoleColor ForegroundColor { get; set; }
}
