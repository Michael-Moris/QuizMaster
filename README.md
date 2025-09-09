# QuizMaster 🎯  

An **Exam System** built in C# using Object-Oriented Programming (OOP) principles.  
It allows creating subjects, generating exams (Final & Practical), and supporting different question types (MCQ & True/False).  
---

## 📌 Features

- ✅ Create **Subjects** and assign an exam.  
- ✅ Two exam types:
  - **Practical Exam** → Shows questions and correct answers at the end.  
  - **Final Exam** → Shows questions, grades, and total score.  
- ✅ Supports **MCQ** and **True/False** questions.  
- ✅ Dynamic input from users (exam time, number of questions, answers, etc.).  
- ✅ Error handling with default values for invalid inputs.  
- ✅ Tracks exam duration. 

---

## 📂 Project Structure

```
OOP_EXAM/
│── Classes/
│ ├── Answer.cs # Represents a single answer option
│ ├── Question.cs # Abstract base class for questions
│ ├── MCQQuestion.cs # Multiple-choice question
│ ├── TrueFalseQuestion.cs # True/False question
│ ├── Exam.cs # Abstract base exam class
│ ├── PracticalExam.cs # Practical exam implementation
│ ├── FinalExam.cs # Final exam implementation
│ └── Subject.cs # Represents a subject and manages exam creation
│
│── Program.cs # Entry point (Main method)
```

---

## 🚀 Getting Started

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/your-username/OOP-Exam-System.git
cd OOP-Exam-System
```
### 2️⃣ Build the Project
```bash
dotnet build
```
### 3️⃣ Run the Application
```bash
dotnet run
```

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!
Feel free to fork the project and submit a pull request.
