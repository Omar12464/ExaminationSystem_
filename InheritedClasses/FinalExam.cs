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
        int marks = 0;


        #region Comments
        //public override void GradeExam()
        //{
        //    int totalMark = 0;
        //    DateTime startTime = DateTime.Now;

        #region cOMMENT
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
        //                totalMark += question.Mark;
        //            }
        //        }
        //    }
        #endregion
        //for (int i = 0; i < Questions.Length; i++)
        //{
        //    if(Questions[i] == null) { continue; }
        //    Console.WriteLine(Questions[i].BodyoftheQuestion);
        //    foreach(var answer in Ques)
        //    {

        //    }
        //}
        //DateTime EndTime = DateTime.Now;
        //double timeSpent= (EndTime-startTime).TotalMinutes;
        //double remaintime=(TimeOfExam - timeSpent);

        //Console.WriteLine($"Start Time of Exam:{startTime}");
        //Console.WriteLine($"Endtime:{EndTime}");
        //Console.WriteLine($"TimeSpent:{timeSpent}");
        //Console.WriteLine($"RemainTime:{remaintime}");
        //Console.WriteLine($"Total Mark:{totalMark}"); 
        #endregion


        public override void ShowCorrectAnswer()
        {
            Console.WriteLine("Final Exam: Correct Answers");
            int marks = 0;
            foreach (var question in Questions)
            {
                if (question == null) continue;
                Console.WriteLine($"{question.BodyoftheQuestion} Correct Answer: {question.RightAnswer.AnswerText},Marks: {question.Mark}");
                if (question.Useranswer == question.RightAnswer)
                {
                    marks+=question.Mark;
                }
            }
            Console.WriteLine($"totalmarks:{marks}");
        }

        public override void ShowExam()
        {
            #region Comments

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
            //GradeExam(); 
            #endregion
            Console.WriteLine("Final Exam:");
            DateTime startTime = DateTime.Now;
            DateTime endtime = DateTime.Now;
            foreach (var question in Questions) {
                if(question == null) continue;
                Console.WriteLine($"{question.BodyoftheQuestion}");
                foreach(var answers in question.AnswerList)
                {
                    if (answers == null) continue;
                    Console.WriteLine($"{answers.AnswerId} {answers.AnswerText}");
                }
                string useranswer=Console.ReadLine();
                if (!(useranswer == null||int.TryParse(useranswer, out int useranswerID))) 
                {
                    Answer selectedAnswer = question.AnswerList.FirstOrDefault(a => a.AnswerId ==useranswerID);
                    question.Useranswer = selectedAnswer;                
                }
            }
            endtime= DateTime.Now;
            double timespent = (endtime - startTime).TotalSeconds;
            double remaintime = (TimeOfExam * 60) - timespent;
            Console.WriteLine($"Start Time of Exam: {startTime:HH:mm:ss}");
            Console.WriteLine($"End Time: {endtime:HH:mm:ss}");
            Console.WriteLine($"Time Spent: {TimeSpan.FromSeconds(timespent):hh\\:mm\\:ss}");
            Console.WriteLine($"Remaining Time: {TimeSpan.FromSeconds(remaintime):hh\\:mm\\:ss}");

        }
        #region Comments
        //private int correctanswer(Question answer)
        //{
        //    int c = 0;
        //    foreach (var question in Questions)
        //    {
        //        if (question == null) { Console.WriteLine("no questions"); continue; }
        //        else
        //        {
        //            if (question.IsCorrect(question.RightAnswer))
        //            {
        //                c+=answer.Mark;
        //            }
        //        }
        //    }
        //    return c;
        //} 
        #endregion
    }
}

