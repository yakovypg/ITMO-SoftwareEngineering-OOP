using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    public void SendMessage(Message message);
}
