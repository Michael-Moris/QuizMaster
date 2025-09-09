namespace QuizMaster.Classes
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public Subject()
        {
            SubjectId = 1;
            SubjectName = "OOP";
        }

        public void ShowWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
 __       __  ________  __         ______    ______   __       __  ________ 
/  |  _  /  |/        |/  |       /      \  /      \ /  \     /  |/        |
$$ | / \ $$ |$$$$$$$$/ $$ |      /$$$$$$  |/$$$$$$  |$$  \   /$$ |$$$$$$$$/ 
$$ |/$  \$$ |$$ |__    $$ |      $$ |  $$/ $$ |  $$ |$$$  \ /$$$ |$$ |__    
$$ /$$$  $$ |$$    |   $$ |      $$ |      $$ |  $$ |$$$$  /$$$$ |$$    |   
$$ $$/$$ $$ |$$$$$/    $$ |      $$ |   __ $$ |  $$ |$$ $$ $$/$$ |$$$$$/    
$$$$/  $$$$ |$$ |_____ $$ |_____ $$ \__/  |$$ \__$$ |$$ |$$$/ $$ |$$ |_____ 
$$$/    $$$ |$$       |$$       |$$    $$/ $$    $$/ $$ | $/  $$ |$$       |
$$/      $$/ $$$$$$$$/ $$$$$$$$/  $$$$$$/   $$$$$$/  $$/      $$/ $$$$$$$$/ 
                                                                            
");
            Console.ResetColor();
        }

        public void CreateExam()
        {
            ShowWelcome();
            Console.WriteLine("Please Enter the Type of Exam (1 for Practical | 2 for Final)");
            string? examTypeInput = Console.ReadLine();
            int examType;
            if (!int.TryParse(examTypeInput, out examType))
            {
                Console.WriteLine("ERROR: Invalid input!... [Defaulting to Final Exam].");
                examType = 2;
            }

            Console.WriteLine("Please Enter the Time For Exam From (30 min to 180 min)");
            string? examTimeInput = Console.ReadLine();
            int examTime;
            if (!int.TryParse(examTimeInput, out examTime))
            {
                Console.WriteLine("ERROR: Invalid input!... [Defaulting to 30 minutes].");
                examTime = 30;
            }

            Console.WriteLine("Please Enter the Number of Questions");
            string? numQuestionsInput = Console.ReadLine();
            int numQuestions;
            if (!int.TryParse(numQuestionsInput, out numQuestions))
            {
                Console.WriteLine("ERROR: Invalid input!... [Defaulting to 1 question].");
                numQuestions = 1;
            }

            if (examType == 1)
            {
                Exam = new PracticalExam(examTime, numQuestions);
            }
            else if (examType == 2)
            {
                Exam = new FinalExam(examTime, numQuestions);
            }
            else
            {
                Console.WriteLine("Invalid Exam Type!... Defaulting to Final Exam.");
                Exam = new FinalExam(examTime, numQuestions);
            }

            Exam.Subject = this;

            for (int i = 0; i < numQuestions; i++)
            {
                Question question;
                string body;
                int mark;

                if (examType == 1)
                {
                    Console.WriteLine("MCQ Question");
                    Console.WriteLine("Please Enter Question Body");
                    string? bodyInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(bodyInput))
                    {
                        Console.WriteLine("ERROR: Empty Body!... [Defaulting to '[Untitled Question]'].");
                        body = "[Untitled Question]";
                    }
                    else
                        body = bodyInput;

                    Console.WriteLine("Please Enter Question Mark");
                    string? markInput = Console.ReadLine();
                    if (!int.TryParse(markInput, out mark))
                    {
                        Console.WriteLine("ERROR: Invalid input!... [Defaulting to 1 mark].");
                        mark = 1;
                    }

                    question = new MCQQuestion(body, mark);

                    List<Answer> answers = new List<Answer>();
                    Console.WriteLine();
                    Console.WriteLine("Choices Of Question");

                    for (int j = 1; j <= 3; j++)
                    {
                        Console.WriteLine($"Please Enter Choice number {j}");
                        string choiceText = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(choiceText))
                        {
                            Console.WriteLine($"ERROR: Invalid input!... [Defaulting to 'Choice {j}'].");
                            choiceText = $"Choice {j}";
                        }
                        answers.Add(new Answer(j, choiceText));
                    }

                    question.Answers = answers.ToArray();

                    Console.WriteLine("Please Enter the right answer id");
                    string? rightIdInput = Console.ReadLine();
                    int rightId;
                    if (!int.TryParse(rightIdInput, out rightId) || rightId < 1 || rightId > question.Answers.Length)
                    {
                        Console.WriteLine("ERROR: Invalid input!... [Defaulting to Answer 1].");
                        rightId = 1;
                    }
                    question.RightAnswer = question.Answers[rightId - 1];
                }
                else
                {
                    Console.WriteLine("Please Enter the Type of Question (1 for MCQ | 2 For True OR False)");
                    string? questionTypeInput = Console.ReadLine();
                    int questionType;
                    if (!int.TryParse(questionTypeInput, out questionType))
                    {
                        Console.WriteLine("ERROR: Invalid input!... [Defaulting to MCQ].");
                        questionType = 1;
                    }

                    Console.WriteLine("Please Enter Question Body");
                    string? bodyInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(bodyInput))
                    {
                        Console.WriteLine("ERROR: Empty Body!... [Defaulting to '[Untitled Question]'].");
                        body = "[Untitled Question]";
                    }
                    else
                        body = bodyInput;

                    Console.WriteLine("Please Enter Question Mark");
                    string? markInput = Console.ReadLine();
                    if (!int.TryParse(markInput, out mark))
                    {
                        Console.WriteLine("ERROR: Invalid input!... [Defaulting to 1 mark].");
                        mark = 1;
                    }

                    if (questionType == 1)
                    {
                        question = new MCQQuestion(body, mark);

                        List<Answer> answers = new List<Answer>();
                        Console.WriteLine("Choices Of Question");

                        for (int j = 1; j <= 3; j++)
                        {
                            Console.WriteLine($"Please Enter Choice number {j}");
                            string choiceText = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(choiceText))
                            {
                                Console.WriteLine($"ERROR: Invalid input!... [Defaulting to 'Choice {j}'].");
                                choiceText = $"Choice {j}";
                            }
                            answers.Add(new Answer(j, choiceText));
                        }

                        question.Answers = answers.ToArray();

                        Console.WriteLine("Please Enter the right answer id");
                        string? rightIdInput = Console.ReadLine();
                        int rightId;
                        if (!int.TryParse(rightIdInput, out rightId) || rightId < 1 || rightId > question.Answers.Length)
                        {
                            Console.WriteLine("ERROR: Invalid input!... [Defaulting to Answer 1].");
                            rightId = 1;
                        }
                        question.RightAnswer = question.Answers[rightId - 1];
                    }
                    else
                    {
                        question = new TrueFalseQuestion(body, mark);

                        Console.WriteLine("Please Enter the right answer id (1 for true | 2 for false)");
                        string? rightIdInput = Console.ReadLine();
                        int rightId;
                        if (!int.TryParse(rightIdInput, out rightId) || rightId < 1 || rightId > 2)
                        {
                            Console.WriteLine("ERROR: Invalid input!... [Defaulting to True (1)].");
                            rightId = 1;
                        }
                        question.RightAnswer = question.Answers[rightId - 1];
                    }
                }
                Exam.Questions[i] = question;
            }

            string? start;
            do
            {
                Console.WriteLine("Do you want to start the exam? (Y/N)");
                start = Console.ReadLine()?.Trim().ToUpper();

                if (start == "Y")
                {
                    Console.Clear();
                    Exam.ShowExam();
                    break;
                }
                else if (start == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You have chosen to exit the exam. Goodbye!...");
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR: Invalid input!... [Please enter 'Y' or 'N'].");
                }
            } while (true);
            Console.WriteLine("Thank you for using the exam system!...");
        }
    }
}
