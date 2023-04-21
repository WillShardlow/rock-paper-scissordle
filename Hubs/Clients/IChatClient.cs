using RockPaperScissordle.Models;

namespace RockPaperScissordle.Hubs.Clients;

public interface IChatClient
{
    Task ReceiveMessage(ChatMessage message);
}