using QuizMaster.Classes;

namespace QuizMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new();
            subject.CreateExam();
        }
    }
}
