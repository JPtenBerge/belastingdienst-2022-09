using Demo.Shared.Entities;
using Microsoft.AspNetCore.SignalR;

namespace DemoProject.Hubs;

public class ChatHub : Hub
{
    public async Task Send(ChatMessageEntity message)
    {
        
        await Clients.All.SendAsync("message", message);
    }
}
