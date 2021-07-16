using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class ExamSubject
    {
        [Key]
        public int ExamSubjectID { get; set; }
        [Required (ErrorMessage = "Please enter the right Exam Subject")]
        public string SubjectName { get; set; }
    }
}