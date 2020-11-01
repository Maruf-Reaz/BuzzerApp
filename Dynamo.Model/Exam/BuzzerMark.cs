using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Model.Exam
{
    public class BuzzerMark
    {
        public int Id { get; set; }
        public int BuzzerNumber { get; set; }

        public int? CorrectAnswer { get; set; }
        public int? WrongAnswer { get; set; }
        public int? NotAnswered { get; set; }
        public Double? TotalMark { get; set; }

    }
}
