using System.ComponentModel.DataAnnotations;

namespace StudentsPortalApp.StudentModel
{
    public class StudentPersonalDetails
    {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string? Name { get; set; }
        public int Class { get; set; }
        public string? Division { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
