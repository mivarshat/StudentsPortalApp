using System.ComponentModel.DataAnnotations;

namespace StudentsPortalApp.StudentModel
{
    public class StudentRecords
    {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public bool Active { get; set; }
        public string? StudentName { get; set; }
    }
}
