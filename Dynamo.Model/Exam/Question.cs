using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Model.Exam
{
    public class Question
    {
        public int Id { get; set; }

       
        public string Description { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public bool IsOption1Correct { get; set; }
        public bool IsOption2Correct { get; set; }
        public bool IsOption3Correct { get; set; }
        public bool IsOption4Correct { get; set; }

        public bool HasOption { get; set; }

        public string Answer { get; set; }
        //public bool HasImage { get; set; }

        //public string ImageBase64 { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public bool IsActive { get; set; }

    }
}
