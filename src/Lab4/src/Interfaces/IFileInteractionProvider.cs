namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IFileInteractionProvider
{
    string ReadText(string path);
    bool Exists(string path);
    void Create(string path);
    void Delete(string path);
    void Rename(string path, string newName);
    string ChangeFileNameInPath(string path, string newName);
    void Move(string sourcePath, string destinationPath);
    void Copy(string sourcePath, string destinationPath);
}
