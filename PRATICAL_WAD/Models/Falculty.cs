using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Falculty
    {
        [Key]
        public int FalcultyID { get; set; }
        [Required(ErrorMessage = "Please enter the right Falculty")]
        public string FalcultyName { get; set; }
    }
}