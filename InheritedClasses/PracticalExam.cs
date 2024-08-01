using ExaminationSystem_.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem_.InheritedClasses
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(double timeOfExam, int numberOfQuestion, Question[] questions)
            : base(timeOfExam, numberOfQuestion, questions)
        {
        }

        public override void GradeExam()
        {
            DateTime startTime = DateTime.Now;
            int totalMarks = 0;

            foreach (var question in Questions)
            {
                if (question == null) continue;
                Console.WriteLine(question.BodyoftheQuestion);

                foreach (var answer in question.AnswerList)
                {
                    if (answer != null)
                    {
                        Console.WriteLine($"{answer.AnswerId}: {answer.AnswerText}");
                    }
                }

                string userAnswer = Console.ReadLine();
                if (userAnswer != null && int.TryParse(userAnswer, out int userAnswerId))
                {
                    Answer selectedAnswer = question.AnswerList.FirstOrDefault(a => a.AnswerId == userAnswerId);
                    if (selectedAnswer != null && selectedAnswer.Equals(question.RightAnswer))
                    {
                        totalMarks += question.Mark;
                    }
                }
            }

            DateTime endTime = DateTime.Now;
            double timeSpent = (endTime - startTime).TotalMilliseconds;
            double remainTime = TimeOfExam - timeSpent;

            Console.WriteLine($"Start Time of Exam: {startTime}");
            Console.WriteLine($"End Time: {endTime}");
            Console.WriteLine($"Time Spent: {timeSpent} ms");
            Console.WriteLine($"Remaining Time: {remainTime} ms");
            Console.WriteLine($"Total Marks: {totalMarks}");
        }

        public override void ShowCorrectAnswer()
        {
            Console.WriteLine("Practical Exam: Correct Answers");
            foreach (var question in Questions)
            {
                if (question == null) continue;
                Console.WriteLine($"{question.BodyoftheQuestion}, Correct Answer: {question.RightAnswer.AnswerText}");
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam:");
            foreach (var question in Questions)
            {
                if (question == null) continue;
                Console.WriteLine($"{question}");
                foreach (var answer in question.AnswerList)
                {
                    if (answer != null)
                    {
                        Console.WriteLine($"{answer.AnswerId}: {answer.AnswerText}");
                    }
                }
            }
            ShowCorrectAnswer();
            GradeExam();
        }
    }
}
