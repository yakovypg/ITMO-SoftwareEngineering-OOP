using Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class FileColorDisplayDriver : DisplayDriver
{
    public FileColorDisplayDriver(string filePath)
        : base(new FileTextWriterToColoredTextWriterAdapter(new FileTextWriter(filePath)))
    {
    }
}
