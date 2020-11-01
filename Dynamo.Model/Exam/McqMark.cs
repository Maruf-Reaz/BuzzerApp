using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Model.Exam
{
    public class McqMark
    {
        public int Id { get; set; }


        public string UserId { get; set; }
        public int  QuestionId { get; set; }
        public Question Question { get; set; }

        public int GivenAnswer { get; set; }
        public int CorrecAnswer { get; set; }
        public int ExamId { get; set; }


    }
}
