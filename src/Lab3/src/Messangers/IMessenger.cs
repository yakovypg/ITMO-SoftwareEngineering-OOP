using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public interface IMessenger
{
    void SendMessage(Message message);
}
