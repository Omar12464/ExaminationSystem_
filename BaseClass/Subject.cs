using ExaminationSystem_.BaseClass;
using ExaminationSystem_.InheritedClasses;
using System;
using System.Reflection.PortableExecutable;

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
            Console.WriteLine("Enter Type Of Exam (1 For Practical | 2 For Final)");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid Input. Please enter 1 for Practical or 2 for Final.");
            }

            Console.WriteLine("Please Enter Time for Exam From (30 min to 180 min)");
            double time;
            while (!double.TryParse(Console.ReadLine(), out time))
            {
                Console.WriteLine("Invalid Input. Please enter a valid duration.");
            }

            Console.WriteLine("Please Enter Number Of Questions");
            int numberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
            {
                Console.WriteLine("Invalid Input. Please enter a valid number of questions.");
            }

            Question[] questions = new Question[numberOfQuestions];
            #region FinalExam
            if (choice == 2)//Final Exam
            {
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    Console.WriteLine("Enter number corresponding to teh question type(1.True|False||2.MCQ)");
                    int questiontype;
                    while (!int.TryParse(Console.ReadLine(), out questiontype) /*|| questiontype != 1 || questiontype != 2*/) { Console.WriteLine("Invalid input"); }
                    if (questiontype == 1) { questions[i] = CraeteTrueFalseExam(); }
                    else if (questiontype == 2)
                    {
                        questions[i] = CraeteMCQ();
                    }
                }
                ExamSubject=new FinalExam(time, numberOfQuestions,questions);
            }
            #endregion
            #region Practical Exam
            else if (choice == 1)
            {
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    questions[i] = CraeteMCQ();
                }
                ExamSubject = new PracticalExam(time, numberOfQuestions, questions);

            } 
            #endregion
        }
        #region Comments
        //    Console.WriteLine("Please Enter Type Of Question (1 For  MCQ | 2 For True/False):");
        //    int questionType;
        //    while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
        //    {
        //        Console.WriteLine("Invalid Input. Please enter 1 for True/False or 2 for MCQ.");
        //    }
        //    Console.Clear();
        //    string header;

        //    Console.WriteLine("Enter the body of the question:");
        //    body = Console.ReadLine();

        //    Console.WriteLine("Enter the mark of the question:");
        //    int mark;
        //    while (!int.TryParse(Console.ReadLine(), out mark))
        //    {
        //        Console.WriteLine("Invalid Input. Please enter a valid mark.");
        //    }

        //    if (questionType == 2) // True/False
        //    {

        //    }
        //    else if (questionType == 1) // MCQ
        //    {
        //        header = "MCQ Question";
        //        Answer[] answers = new Answer[4];
        //        for (int j = 0; j < answers.Length; j++)
        //        {
        //            Console.WriteLine($"Enter answer option {j + 1}:\n");
        //            string answerText = Console.ReadLine();
        //            answers[j] = new Answer(j + 1, answerText);
        //        }

        //        Console.WriteLine("Enter the correct answer (choose the number corresponding to the correct option):");
        //        int correctAnswer;
        //        while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 4)
        //        {
        //            Console.WriteLine("Invalid Input. Please enter a number between 1 and 4.");
        //        }

        //        Answer correctAnswerObject = answers[correctAnswer - 1];
        //        questions[i] = new MCQ(header, body, mark, correctAnswerObject, answers);
        //    }

        //    Console.Clear();
        //}
        //else if (choice == 1)
        //{
        //    string header;
        //    for (int i = 0; i < questions.Length; i++)
        //    {
        //        header = "MCQ Question";
        //        Answer[] answers = new Answer[4];
        //        for (int j = 0; j < answers.Length; j++)
        //        {
        //            Console.WriteLine($"Enter answer option {j + 1}:\n");
        //            string answerText = Console.ReadLine();
        //            answers[j] = new Answer(j + 1, answerText);
        //        }

        //        Console.WriteLine("Enter the correct answer (choose the number corresponding to the correct option):");
        //        int correctAnswer;
        //        while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 4)
        //        {
        //            Console.WriteLine("Invalid Input. Please enter a number between 1 and 4.");
        //        }

        //        Answer correctAnswerObject = answers[correctAnswer - 1];
        //        questions[i] = new MCQ(header, body, mark, correctAnswerObject, answers);
        //    }
        //}

        //    if (choice == 2)
        //    {
        //        ExamSubject = new FinalExam(time, numberOfQuestions, questions);
        //    }
        //    else if (choice == 1)
        //    {
        //        ExamSubject = new PracticalExam(time, numberOfQuestions, questions);
        //    }
        //} 
        #endregion
        #region Type Of Exams
        private Question CraeteTrueFalseExam()
        {
            string header = "True|False Question";
            Console.WriteLine("Enter Body Of Question");
            string body = Console.ReadLine();
            Console.WriteLine("Enter the mark of the question:");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark))
            {
                Console.WriteLine("Invalid Input. Please enter a valid mark.");
            }
            Console.Clear();
            Answer[] answers = { new Answer(1, "True"), new Answer(2, "False") };

            Console.WriteLine("Enter your answer (1 for True / 2 for False):");
            int correctAnswer;
            while (!int.TryParse(Console.ReadLine(), out correctAnswer) || (correctAnswer != 1 && correctAnswer != 2))
            {
                Console.WriteLine("Invalid Input. Please enter 1 for True or 2 for False.");
            }

            Answer correctAnswerObject = answers[correctAnswer - 1];
            return new TrueFalse(header, body, mark, correctAnswerObject, answers);
        }
        private Question CraeteMCQ()
        {
            string header = "MCQ";

            Console.WriteLine("Enter Body of Question");
            string body = Console.ReadLine();

            Console.WriteLine("Enter mark of Question");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.WriteLine("Invalid Input. Enter a positive integer.");
            }

            Answer[] answers = new Answer[4];
            for (int j = 0; j < answers.Length; j++)
            {
                Console.WriteLine($"Enter answer {j + 1}");
                string answerText = Console.ReadLine();
                answers[j] = new Answer(j + 1, answerText);
            }

            Console.WriteLine("Enter the number of the correct answer (1-4)");
            int correctAnswerIndex;
            while (!int.TryParse(Console.ReadLine(), out correctAnswerIndex) || correctAnswerIndex < 1 || correctAnswerIndex > 4)
            {
                Console.WriteLine("Invalid Input. Enter a number between 1 and 4.");
            }
            Answer correctAnswer = answers[correctAnswerIndex - 1];

            return new MCQ(header, body, mark, correctAnswer, answers);
        }
    } 
    #endregion

}
