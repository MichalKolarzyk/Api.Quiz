using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.QuizSession.ExtenrnalEvents
{
    public interface ISessionComunicator
    {
        Task SendMessageToAll(string message);
    }
}
