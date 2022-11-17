using System.Reflection;

namespace Api.Quiz
{
    public static class AssemblyApiQuiz
    {
        public static Assembly Assembly { get; set; } = typeof(AssemblyApiQuiz).Assembly;
    }
}
