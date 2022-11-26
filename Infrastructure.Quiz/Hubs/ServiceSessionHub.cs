using Application.Quiz.QuizSession.ExtenrnalEvents;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Quiz.Hubs
{
    public class ServiceSessionHub : Hub
    {
        public async Task SendMessage(string groupName, string user, string message)
        {
            await Clients.Group(groupName).SendAsync("Chat", user, message);
        }

        public async Task JoinRoom(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveRoom(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName); ;
        }
    }
}
