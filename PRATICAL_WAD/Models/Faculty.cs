using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace PRATICAL_WAD.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui long nhap ten khoa ")]
        public string facultyName { get; set; }
        //  public virtual Exam Exam { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}