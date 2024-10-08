namespace StudentsPortalApp.StudentModel
{
    public class ErrorModel
    {
        public int Code { get; set; }
        public string? Text { get; set; }
        public Dictionary<string, string>? Context { get; set; }
    }
}
