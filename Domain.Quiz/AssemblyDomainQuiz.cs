using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz
{
    public static class AssemblyDomainQuiz
    {
        public static Assembly Assembly { get; set; } = typeof(AssemblyDomainQuiz).Assembly;
    }
}
