using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Authentications
{
    public interface IAuthenticationSettings
    {
        string Key { get; }
        int ExpireTimeInSeconds { get; }
    }
}
