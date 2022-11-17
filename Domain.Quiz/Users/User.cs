using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Users
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string HashPassword { get; set; } = string.Empty;
    }
}
