namespace QuizMaster.Classes
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer RightAnswer { get; set; }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"Header: {Header}, Body: {Body}, Mark: {Mark}";
        }
    }
}
