using FluentValidation;

namespace DevFreela.Application.Commands.Project.Update.Validator;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(cmd => cmd.Id)
            .GreaterThan(0);

        RuleFor(cmd => cmd.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(cmd => cmd.Description)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(cmd => cmd.TotalCost)
            .GreaterThan(0);
    }
}