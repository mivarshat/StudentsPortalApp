using System.ComponentModel.DataAnnotations;

namespace StudentsPortalApp.Models
{
    public class StudentRecords
    {
        [Key]
        public int RollNo { get; set; }
        public string? StudentName { get; set; }

    }
}
