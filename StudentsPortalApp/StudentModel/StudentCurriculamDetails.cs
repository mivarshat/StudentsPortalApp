using System.ComponentModel.DataAnnotations;

namespace StudentsPortalApp.StudentModel
{
    public class StudentCurriculamDetails
    {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public int Class { get; set; }
        public int MathsMarks { get; set; }
        public int ScienceMarks { get; set; }
        public int EnglishMarks { get; set; }
        public int SSTMarks { get; set; }
        public int MarathiMarks { get; set; }
        public int HindiMarks { get; set; }
        public int ComputerMarks { get; set; }
    }
}
