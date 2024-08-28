using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task CallBullshit(string user)
        {
            await Clients.All.SendAsync("CalledBullshit", user);
        }
    }
}
