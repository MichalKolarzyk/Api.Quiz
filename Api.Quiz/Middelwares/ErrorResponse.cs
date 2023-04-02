using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Abstracts
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
        public string StackTrace { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
