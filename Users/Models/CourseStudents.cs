using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Users.Models
{
    public class CourseStudents
    {
        public int  ID { get; set; }
        public string StudentID { get; set; }
        public int CourseID { get; set; }
    }
}