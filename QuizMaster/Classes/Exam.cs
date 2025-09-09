namespace QuizMaster.Classes
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject Subject { get; set; }

        protected Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        protected int GetValidAnswerId(Question question)
        {
            int userAnswerId;
            while (true)
            {
                Console.Write("Your Answer ID => ");
                if (int.TryParse(Console.ReadLine(), out userAnswerId) &&
                    question.Answers.Any(a => a.AnswerId == userAnswerId))
                {
                    return userAnswerId;
                }

                Console.WriteLine("ERROR: Invalid input! Please enter a valid Answer ID from the list above!...");
            }
        }

        public abstract void ShowExam();
    }
}
