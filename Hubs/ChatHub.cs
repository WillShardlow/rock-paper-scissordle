using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RockPaperScissordle.Hubs.Clients;
using RockPaperScissordle.Models;

namespace RockPaperScissordle.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}