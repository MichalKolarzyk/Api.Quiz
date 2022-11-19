using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Users
{
    public class LoginUserResponse
    {
        public string Token { get; set; } = string.Empty;
        public bool Succeed { get; set; }
    }
}
