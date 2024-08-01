using ExaminationSystem_.BaseClass;
using ExaminationSystem_.InheritedClasses;
using System;

namespace ExaminationSystem_.BaseClass
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamSubject { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            Console.WriteLine("Enter type of exam (1. Final / 2. Practical):");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid Input. Please enter 1 for Final or 2 for Practical.");
            }

            Console.WriteLine("Enter exam duration in milliseconds:");
            double time;
            while (!double.TryParse(Console.ReadLine(), out time))
            {
                Console.WriteLine("Invalid Input. Please enter a valid duration.");
            }

            Console.WriteLine("Enter number of questions:");
            int numberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
            {
                Console.WriteLine("Invalid Input. Please enter a valid number of questions.");
            }

            Question[] questions = new Question[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("Exam must have (1. True/False / 2. MCQ)");
                Console.WriteLine("Enter question type (1. True/False / 2. MCQ):");
                int questionType;
                while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
                {
                    Console.WriteLine("Invalid Input. Please enter 1 for True/False or 2 for MCQ.");
                }

                Console.WriteLine("Enter the header of the question:");
                string header = Console.ReadLine();

                Console.WriteLine("Enter the body of the question:");
                string body = Console.ReadLine();

                Console.WriteLine("Enter the mark of the question:");
                int mark;
                while (!int.TryParse(Console.ReadLine(), out mark))
                {
                    Console.WriteLine("Invalid Input. Please enter a valid mark.");
                }

                if (questionType == 1) // True/False
                {
                    Answer[] answers = { new Answer(1, "True"), new Answer(2, "False") };

                    Console.WriteLine("Enter your answer (1 for True / 2 for False):");
                    int correctAnswer;
                    while (!int.TryParse(Console.ReadLine(), out correctAnswer) || (correctAnswer != 1 && correctAnswer != 2))
                    {
                        Console.WriteLine("Invalid Input. Please enter 1 for True or 2 for False.");
                    }

                    Answer correctAnswerObject = answers[correctAnswer - 1];
                    questions[i] = new TrueFalse(header, body, mark, correctAnswerObject, answers);
                }
                else if (questionType == 2) // MCQ
                {
                    Answer[] answers = new Answer[4];
                    for (int j = 0; j < answers.Length; j++)
                    {
                        Console.WriteLine($"Enter answer option {j + 1}:");
                        string answerText = Console.ReadLine();
                        answers[j] = new Answer(j + 1, answerText);
                    }

                    Console.WriteLine("Enter the correct answer (choose the number corresponding to the correct option):");
                    int correctAnswer;
                    while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 4)
                    {
                        Console.WriteLine("Invalid Input. Please enter a number between 1 and 4.");
                    }

                    Answer correctAnswerObject = answers[correctAnswer - 1];
                    questions[i] = new MCQ(header, body, mark, correctAnswerObject, answers);
                }

                Console.Clear();
            }

            if (choice == 1)
            {
                ExamSubject = new FinalExam(time, numberOfQuestions, questions);
            }
            else if (choice == 2)
            {
                ExamSubject = new PracticalExam(time, numberOfQuestions, questions);
            }
        }
    }
}
