using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem_.BaseClass
{
    internal abstract class Exam : ICloneable,IComparable<Exam>
    {
        public double TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }

        public Question[] Questions { get; set; }

        public Exam(double timeOfExam, int numberOfQuestion, Question[] question)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestion;
            Questions = question?? new Question[numberOfQuestion];
        }

        public  object Clone(){
            Question[] clonedQuestions = Questions.Select(q => (Question)q.Clone()).ToArray();
            Exam clonedExam=(Exam) MemberwiseClone();
            clonedExam.Questions = clonedQuestions;
            return clonedExam;

        }

        public abstract void ShowExam();

        public int CompareTo(Exam? other)
        {
            return NumberOfQuestions.CompareTo(other?.NumberOfQuestions);
        }

        public abstract void ShowCorrectAnswer();
    }

}
