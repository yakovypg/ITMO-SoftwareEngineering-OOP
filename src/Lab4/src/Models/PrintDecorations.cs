using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class PrintDecorations
{
    private const string _defaultFileMark = "- ";
    private const string _defaultFolderMark = "#";
    private const string _defaultMarginMark = "    ";

    public PrintDecorations(
        string fileMark = _defaultFileMark,
        string folderMark = _defaultFolderMark,
        string marginMark = _defaultMarginMark)
    {
        FileMark = fileMark ?? throw new ArgumentNullException(nameof(fileMark));
        FolderMark = folderMark ?? throw new ArgumentNullException(nameof(fileMark));
        MarginMark = marginMark ?? throw new ArgumentNullException(nameof(fileMark));
    }

    public string FileMark { get; }
    public string FolderMark { get; }
    public string MarginMark { get; }
}
