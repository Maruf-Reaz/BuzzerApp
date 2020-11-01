using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Model.Exam
{
    public class Exam
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Name { get; set; }

        public List<Question> Questions { get; set; }


    }




}

