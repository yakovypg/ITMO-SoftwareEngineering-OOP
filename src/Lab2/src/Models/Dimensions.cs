using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public readonly struct Dimensions : IEquatable<Dimensions>
{
    public Dimensions(double width = 0, double height = 0, double depth = 0)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }

    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }

    public double Volume => Width * Height * Depth;

    public static bool operator ==(Dimensions a, Dimensions b)
    {
        return a.Width == b.Width
            && a.Height == b.Height
            && a.Depth == b.Depth;
    }

    public static bool operator !=(Dimensions a, Dimensions b)
    {
        return !(a == b);
    }

    public bool Equals(Dimensions other)
    {
        return this == other;
    }

    public override bool Equals(object? obj)
    {
        return obj is Dimensions other && this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height, Depth);
    }
}
