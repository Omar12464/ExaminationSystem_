using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem_.BaseClass
{
    internal abstract  class Question:ICloneable
    {
        public string Headerofthequestion { get; set; }
        public string BodyoftheQuestion { get; set; }
        public int Mark { get; set; }
        public Answer Useranswer { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        public Question(string head,string body,int mark, Answer right, Answer[] answers)
        {
            Headerofthequestion = head;
            BodyoftheQuestion = body;
            Mark = mark;
            AnswerList = answers;
            RightAnswer = right;
        }

        //public override string ToString()
        public bool IsCorrect(Answer answer)
        {
            return answer!=null&&answer.Equals(RightAnswer);
        }

        public abstract object Clone();
    }

}
