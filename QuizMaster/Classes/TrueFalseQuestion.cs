namespace QuizMaster.Classes
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, int mark) : base("True/False Question", body, mark)
        {
            Answers =
            [
                new Answer(1,"True"),
                new Answer(2,"False")
            ];
        }
    }
}
