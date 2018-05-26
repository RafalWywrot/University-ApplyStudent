using ApplyStudent.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyStudent.Service
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext() : base("ApplyConnection") {}
        public DbSet<Student> Students { get; set; }
    }
}
