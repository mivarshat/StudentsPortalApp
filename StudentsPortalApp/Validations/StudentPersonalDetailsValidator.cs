using FluentValidation;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Validations
{
    public class StudentPersonalDetailsValidator : AbstractValidator<StudentPersonalDetails>
    {
        public StudentPersonalDetailsValidator()
        {
            RuleFor(x => x.RollNo)
                .NotNull().NotEmpty()                
                .WithMessage("Please Enter Roll No");

            RuleFor(x => x.Name)
              .NotNull().NotEmpty()
              .WithMessage("Please Enter Name");

            RuleFor(x => x.Class).InclusiveBetween(1, 10)
             .WithMessage("Please Enter Class between 1 to 10")
             .NotNull().NotEmpty()
             .WithMessage("Please Enter Class");

            RuleFor(x => x.Division).MaximumLength(1).MinimumLength(1)
             .NotNull().NotEmpty()
             .WithMessage("Please Enter Division");

            RuleFor(x => x.Phone)
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Phone");

            RuleFor(x => x.Email).EmailAddress()
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Email");

            RuleFor(x => x.Address)
               .NotNull().NotEmpty()
               .WithMessage("Please Enter Address");
        }
    }
}
