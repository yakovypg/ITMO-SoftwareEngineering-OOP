using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IDestination
{
    void SendMessage(Message message);
}
