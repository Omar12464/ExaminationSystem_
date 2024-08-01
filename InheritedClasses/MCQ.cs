using ExaminationSystem_.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem_.InheritedClasses
{
    internal class MCQ:Question
    {
        public MCQ(string head, string body, int mark, Answer rightanswer , Answer[]  answerlist) : base(head,body,mark,rightanswer,answerlist)
        {
        }

        public override object Clone()
        {
            return new TrueFalse(Headerofthequestion, BodyoftheQuestion, Mark, (Answer)RightAnswer.Clone(), AnswerList.Select(a => (Answer)a.Clone()).ToArray());
        }

        public override string ToString()
        {
            return $"{Headerofthequestion}:{BodyoftheQuestion}(True/False)";
        }
    }
}
