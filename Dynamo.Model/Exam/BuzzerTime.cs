using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Model.Exam
{
    public class BuzzerTime
    {
        public int Id { get; set; }

        public int BuzzerNumber { get; set; }

        public DateTime? EnableTime { get; set; }

        public DateTime? PressTime { get; set; }

        public bool IsFirst { get; set; }

    }
}
