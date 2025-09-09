namespace QuizMaster.Classes
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            DateTime startTime = DateTime.Now;
            Dictionary<Question, Answer> userAnswers = new Dictionary<Question, Answer>();

            for (int i = 0; i < Questions.Length; i++)
            {
                Question question = Questions[i];
                Console.WriteLine($"Question {i + 1}: {question.Body}");
                foreach (Answer answer in question.Answers)
                {
                    Console.WriteLine(answer);
                }

                int userAnswerId = GetValidAnswerId(question);
                Answer userAnswer = question.Answers.First(a => a.AnswerId == userAnswerId);
                userAnswers[question] = userAnswer;
            }

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            Console.Clear();
            foreach (KeyValuePair<Question, Answer> kvp in userAnswers)
            {
                int questionIndex = Array.IndexOf(Questions, kvp.Key) + 1;
                Console.WriteLine($"Question {questionIndex}: {kvp.Key.Body}");
                Console.WriteLine($"Your Answer => {kvp.Value.AnswerText}");
                Console.WriteLine($"Right Answer => {kvp.Key.RightAnswer.AnswerText}\n");
            }

            Console.WriteLine($"Time = {duration}");
        }
    }
}
