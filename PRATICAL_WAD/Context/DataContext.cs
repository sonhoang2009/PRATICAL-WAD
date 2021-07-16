using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PRATICAL_WAD.Models;

namespace PRATICAL_WAD.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("PRATICAL")
        {

        }

        public System.Data.Entity.DbSet<PRATICAL_WAD.Models.Classroom> Classrooms { get; set; }

        public System.Data.Entity.DbSet<PRATICAL_WAD.Models.Exam> Exams { get; set; }

        public System.Data.Entity.DbSet<PRATICAL_WAD.Models.ExamSubjects> ExamSubjects { get; set; }

        public System.Data.Entity.DbSet<PRATICAL_WAD.Models.Faculty> Faculties { get; set; }
    }
}