namespace QuizMaster.Classes
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string? answerText)
        {
            if (id <= 0)
            {
                Console.WriteLine("ERROR: Invalid Answer ID!... [Defaulting to 1].");
                AnswerId = 1;
            }
            else
                AnswerId = id;

            if (string.IsNullOrWhiteSpace(answerText))
            {
                Console.WriteLine("ERROR: Invalid Answer Text!... [Defaulting to 'No Answer'].");
                AnswerText = "No Answer";
            }
            else
                AnswerText = answerText;
        }

        public override string ToString() => $"Answer ID: {AnswerId}, Text: {AnswerText}";
    }
}
