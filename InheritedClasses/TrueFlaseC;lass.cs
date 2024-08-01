using ExaminationSystem_.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem_.InheritedClasses
{
    internal class TrueFalse : Question
    {
        public TrueFalse(string head,string body,int mark, Answer rightanswer,Answer[] answers):base(head, body, mark, rightanswer, answers)
        {
        }

        public override object Clone()
        {
            return new TrueFalse(Headerofthequestion, BodyoftheQuestion, Mark, (Answer)RightAnswer.Clone(), AnswerList.Select(a => (Answer)a.Clone()).ToArray());

        }
        public override string ToString()
        {
            return $"{Headerofthequestion}: {BodyoftheQuestion} (True/False)";
        }
    }
}
