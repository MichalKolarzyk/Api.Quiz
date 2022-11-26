using Application.Quiz.QuizSession.ExtenrnalEvents;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Hubs
{
    public class ServiceSessionHubInternal : ISessionComunicator
    {
        IHubContext<ServiceSessionHub> _hubContext;

        public ServiceSessionHubInternal(IHubContext<ServiceSessionHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageToAll(string message)
        {
            await _hubContext.Clients.All.SendAsync("TestMessage", message);
        }
    }
}
