using FluentValidation;

namespace DevFreela.Application.Commands.Project.Create.Validator;
public class InsertProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public InsertProjectValidator()
    {
        RuleFor(cmd => cmd.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(cmd => cmd.Description)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(cmd => cmd.IdClient)
            .GreaterThan(0);

        RuleFor(cmd => cmd.IdFreeLancer)
            .GreaterThan(0);

        RuleFor(cmd => cmd.TotalCost)
            .GreaterThan(0);
    }
}
