using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : Command
{
    public DisconnectCommand(FileSystem? fileSystem = null)
        : base(fileSystem)
    {
    }

    public override void Execute()
    {
        if (FileSystem is null)
            throw new FileSystemNotSpecifiedException();

        if (!FileSystem.IsConnected)
            throw new FileSystemNotConnectedException();

        FileSystem.Disconnect();
    }
}
