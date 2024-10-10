using FluentValidation;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Validations
{
    public class StudentCurriculamDetailsValidator : AbstractValidator<StudentCurriculamDetails>
    {
        public StudentCurriculamDetailsValidator()
        {
            RuleFor(x => x.RollNo)
                .NotNull().NotEmpty()
                .WithMessage("Please Enter Roll No");

            RuleFor(x => x.Class).InclusiveBetween(1, 10)
                .WithMessage("Please Enter Class between 1 to 10")
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Class");

            RuleFor(x => x.SSTMarks).InclusiveBetween(1, 100)
                .WithMessage("Please Enter Marks between 1 to 100")
              .NotNull().NotEmpty()
              .WithMessage("Please Enter SST Marks");

            RuleFor(x => x.EnglishMarks).InclusiveBetween(1, 100)
                .WithMessage("Please Enter Marks between 1 to 100")
             .NotNull().NotEmpty()
             .WithMessage("Please Enter English Marks");

            RuleFor(x => x.MathsMarks).InclusiveBetween(1, 100)
                .WithMessage("Please Enter Marks between 1 to 100")
             .NotNull().NotEmpty()
             .WithMessage("Please Enter Maths Marks");

            RuleFor(x => x.MarathiMarks).InclusiveBetween(1, 100)
                .WithMessage("Please Enter Marks between 1 to 100")
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Marathi Marks");

            RuleFor(x => x.ScienceMarks).InclusiveBetween(1, 100)
                .WithMessage("Please Enter Marks between 1 to 100")
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Science Marks");

            RuleFor(x => x.ComputerMarks).InclusiveBetween(1, 100)
                .WithMessage("Please Enter Marks between 1 to 100")
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Computer Marks");

            RuleFor(x => x.HindiMarks).InclusiveBetween(1, 100)
                .WithMessage("Please Enter Marks between 1 to 100")
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Hindi Marks");
        }
    }
}
