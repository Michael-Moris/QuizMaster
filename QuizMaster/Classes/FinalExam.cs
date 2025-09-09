namespace QuizMaster.Classes
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            DateTime startTime = DateTime.Now;
            Dictionary<Question, Answer> userAnswers = new Dictionary<Question, Answer>();
            int userGrade = 0;
            int totalGrade = 0;

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

                totalGrade += question.Mark;
                if (userAnswer.AnswerId == question.RightAnswer.AnswerId)
                {
                    userGrade += question.Mark;
                }
            }

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            foreach (KeyValuePair<Question, Answer> kvp in userAnswers)
            {
                int questionIndex = Array.IndexOf(Questions, kvp.Key) + 1;
                Console.WriteLine($"Question {questionIndex}: {kvp.Key.Body}");
                Console.WriteLine($"Your Answer => {kvp.Value.AnswerText}");
            }

            Console.Clear();
            Console.WriteLine($"Your Grade is {userGrade} from {totalGrade}");
            Console.WriteLine($"Time = {duration}");
        }
    }
}
