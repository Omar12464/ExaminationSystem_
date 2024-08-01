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
        int marks = 0;


        public override void ShowCorrectAnswer()
        {
            Console.WriteLine("Final Exam: Correct Answers");
            foreach (var question in Questions)
            {
                if (question == null) continue;
                Console.WriteLine($" Correct Answer: {question.RightAnswer.AnswerText},Marks: {question.Mark}");
                if (question.Useranswer == question.RightAnswer)
                {
                    marks += question.Mark;
                }
            }
            Console.WriteLine($"totalmarks:{marks}");
        }

        public override void ShowExam()
        {
            //int marks = 0;
            DateTime starttime= DateTime.Now;
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
                string useranswer = Console.ReadLine();
                if (!(useranswer == null || int.TryParse(useranswer, out int useranswerID)))
                {
                    Answer selectedAnswer = question.AnswerList.FirstOrDefault(a => a.AnswerId == useranswerID);
                    question.Useranswer = selectedAnswer;
                }
            }
            DateTime endtime = DateTime.Now;
            double timespent = (endtime - starttime).TotalSeconds;
            double remaintime = (TimeOfExam*60) - timespent;
            Console.WriteLine($"Start Time of Exam: {starttime:HH:mm:ss}");
            Console.WriteLine($"End Time: {endtime:HH:mm:ss}");
            Console.WriteLine($"Time Spent: {TimeSpan.FromSeconds(timespent):hh\\:mm\\:ss}");
            Console.WriteLine($"Remaining Time: {TimeSpan.FromSeconds(remaintime):hh\\:mm\\:ss}");
        }


    }



    #region Comments
    //public override void ShowExam()
    //{

    //}
    //public override void GradeExam()
    //{
    //    DateTime startTime = DateTime.Now;
    //    int totalMarks = 0;

    //    foreach (var question in Questions)
    //    {
    //        if (question == null) continue;
    //        Console.WriteLine(question.BodyoftheQuestion);

    //        foreach (var answer in question.AnswerList)
    //        {
    //            if (answer != null)
    //            {
    //                Console.WriteLine($"{answer.AnswerId}: {answer.AnswerText}");
    //            }
    //        }

    //        string userAnswer = Console.ReadLine();
    //        if (userAnswer != null && int.TryParse(userAnswer, out int userAnswerId))
    //        {
    //            Answer selectedAnswer = question.AnswerList.FirstOrDefault(a => a.AnswerId == userAnswerId);
    //            if (selectedAnswer != null && selectedAnswer.Equals(question.RightAnswer))
    //            {
    //                totalMarks += question.Mark;
    //            }
    //        }
    //    }

    //DateTime endTime = DateTime.Now;
    //double timeSpent = (endTime - startTime).TotalMilliseconds;
    //double remainTime = TimeOfExam - timeSpent;

    //Console.WriteLine($"Start Time of Exam: {startTime}");
    //Console.WriteLine($"End Time: {endTime}");
    //Console.WriteLine($"Time Spent: {timeSpent} ms");
    //Console.WriteLine($"Remaining Time: {remainTime} ms");
    //Console.WriteLine($"Total Marks: {totalMarks}"); 
    #endregion
}

