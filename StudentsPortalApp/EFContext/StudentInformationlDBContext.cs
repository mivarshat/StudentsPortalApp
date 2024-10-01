using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.EFContext
{
    public class StudentInformationlDBContext:DbContext
    {
        public StudentInformationlDBContext(DbContextOptions<StudentInformationlDBContext> contextOptions): base(contextOptions)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer()
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<StudentRecords> StudentRecords { get; set; }
        public DbSet<StudentPersonalDetails> StudentPersonalDetails { get; set; }
        public DbSet<StudentCurriculamDetails> StudentCurriculamDetails { get; set; }
    }
}
