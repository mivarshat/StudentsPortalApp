using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.Models;

namespace StudentsPortalApp.EFContext
{
    public class StudentPortalDBContext: DbContext
    {
        public StudentPortalDBContext(DbContextOptions<StudentPortalDBContext> options):base(options)
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
