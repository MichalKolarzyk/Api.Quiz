using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz
{
    public class AssemblyApplicationQuiz
    {
        public static Assembly Assembly { get; set; } = typeof(AssemblyApplicationQuiz).Assembly;
    }
}
