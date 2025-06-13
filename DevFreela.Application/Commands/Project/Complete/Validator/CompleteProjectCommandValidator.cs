using FluentValidation;

namespace DevFreela.Application.Commands.Project.Complete.Validator;

public class CompleteProjectCommandValidator : AbstractValidator<CompleteProjectCommand>
{
    public CompleteProjectCommandValidator()
    {
        RuleFor(cmd => cmd.Id)
            .GreaterThan(0);
    }
}