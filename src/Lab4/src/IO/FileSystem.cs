using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public abstract class FileSystem
{
    protected FileSystem()
    {
    }

    public string? Root { get; protected set; }
    public string? WorkingDirectory { get; protected set; }
    public FileSystemMode? ConnectionMode { get; protected set; }
    public bool IsConnected { get; protected set; }

    public IFileInteractionProvider? FileInteractionProvider { get; protected set; }
    public IDirectoryInteractionProvider? DirectoryInteractionProvider { get; protected set; }

    public virtual void Move(string newWorkingDirectory)
    {
        ArgumentNullException.ThrowIfNull(newWorkingDirectory, nameof(newWorkingDirectory));

        if (Root is null)
            throw new FileSystemNotConnectedException();

        if (DirectoryInteractionProvider is null)
            throw new FileSystemNotConnectedCorrectlyException();

        string absolutePath = GetAbsolutePath(newWorkingDirectory);

        if (!DirectoryInteractionProvider.Exists(absolutePath))
            throw new DirectoryNotFoundException($"Directory {absolutePath} does not exists");

        WorkingDirectory = absolutePath;
    }

    public virtual void Connect(string path, FileSystemMode mode)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        switch (mode)
        {
            case FileSystemMode.Local:
                FileInteractionProvider = new LocalFileInteractionProvider();
                DirectoryInteractionProvider = new LocalDirectoryInteractionProvider();
                break;

            default:
                throw new NotSupportedException();
        }

        if (!DirectoryInteractionProvider.Exists(path))
            throw new DirectoryNotFoundException($"Directory {path} does not exists");

        Root = path;
        WorkingDirectory = path;
        ConnectionMode = mode;
        IsConnected = true;
    }

    public virtual void Disconnect()
    {
        Root = null;
        WorkingDirectory = null;
        ConnectionMode = null;

        FileInteractionProvider = null;
        DirectoryInteractionProvider = null;

        IsConnected = false;
    }

    public abstract string GetAbsolutePath(string path);
}
