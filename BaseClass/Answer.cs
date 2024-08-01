using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem_.BaseClass
{
    internal class Answer:ICloneable
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answertext)
        {
            AnswerId = answerId;
            AnswerText = answertext;
        }
        public object Clone()
        {
            return new Answer( AnswerId,AnswerText);
        }

        public override bool Equals(object obj)
        {
            if (obj is Answer otherAnswer)
            {
                return AnswerText.Equals(otherAnswer.AnswerText, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
        public override string ToString()
        {
            return $"{AnswerId} {AnswerText}";
        }
    }
}
