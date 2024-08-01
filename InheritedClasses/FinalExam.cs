using ExaminationSystem_.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem_.InheritedClasses
{
    internal class FinalExam : Exam
    {
        public FinalExam(double timeOfExam, int numberOfQuestion, Question[] question) : 
            base(timeOfExam, numberOfQuestion, question)
        {

        }

        public override void GradeExam()
        {
            int totalMark = 0;
            DateTime startTime = DateTime.Now;

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
                        totalMark += question.Mark;
                    }
                }
            }
            DateTime EndTime = DateTime.Now;
            double timeSpent= (EndTime-startTime).TotalMinutes;
            double remaintime=(TimeOfExam - timeSpent);

            Console.WriteLine($"Start Time of Exam:{startTime}");
            Console.WriteLine($"Endtime:{EndTime}");
            Console.WriteLine($"TimeSpent:{timeSpent}");
            Console.WriteLine($"RemainTime:{remaintime}");
            Console.WriteLine($"Total Mark:{totalMark}");


        }

        public override void ShowCorrectAnswer()
        {
            Console.WriteLine("Final Exam: Correct Answers");
            foreach (var question in Questions)
            {
                if (question == null) continue;
                Console.WriteLine($"{question.BodyoftheQuestion}, Correct Answer: {question.RightAnswer.AnswerText}");
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine("Final Exam:");
            //foreach (var question in Questions)
            //{
            //    if (question == null) continue;
            //    Console.WriteLine($"{question}");
            //    foreach (var answer in question.AnswerList)
            //    {
            //        if (answer != null)
            //        {
            //            Console.WriteLine($"{answer.AnswerId}: {answer.AnswerText}");
            //        }
            //    }
            //}
            GradeExam();
        }
        //private int CorrectAnswer()
        //{
        //    int c = 0;
        //    foreach (var question in Questions)
        //    {
        //        if (question == null) { Console.WriteLine("no questions"); continue; }
        //        else
        //        {
        //            if (question.IsCorrect(question.RightAnswer))
        //            {
        //                c++;
        //            }
        //        }
        //    }
        //    return c;
        //}
    }
}
