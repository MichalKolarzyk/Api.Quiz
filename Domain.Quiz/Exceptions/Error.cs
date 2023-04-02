using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Exceptions
{
    public class Error
    {
        public Error(string message, string field, int code)
        {
            Message = message;
            Field = field;
            Code = code;
        }

        public Error(string message, int code)
        {
            Message = message;
            Field = "";
            Code = code;
        }

        public string Message { get; set; } = "";
        public string Field { get; set; } = "";
        public int Code { get; set; } 
    }
}
