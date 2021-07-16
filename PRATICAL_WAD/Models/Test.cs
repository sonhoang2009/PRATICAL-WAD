using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Exam.Models
{
    public class Test
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Start Time(HH:MM)")]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Doesn't match format Type: hh:mm")]
        public string Starttime { get; set; }
        [Required(ErrorMessage = "Enter Date (dd/MM/yyyy)")]
        [RegularExpression(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$", ErrorMessage = "Doesn't match format Type: dd/MM/yyyy")]
        public string ExamDate { get; set; }
        [Required(ErrorMessage = "Enter Time (min)")]
        [Range(0, 300)]
        public string ExamDur { get; set; }
        public int ClassroomID { get; set; }
        public int ExamSubjectID { get; set; }
        public int FalcultyID { get; set; }
        public int StatusID { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual ExamSubject ExamSubject { get; set; }
        public virtual Falculty Falculty { get; set; }
        public virtual Status Status { get; set; }
    }
}