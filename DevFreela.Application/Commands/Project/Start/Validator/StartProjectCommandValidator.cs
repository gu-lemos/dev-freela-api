using FluentValidation;

namespace DevFreela.Application.Commands.Project.Start.Validator;

public class StartProjectCommandValidator : AbstractValidator<StartProjectCommand>
{
    public StartProjectCommandValidator()
    {
        RuleFor(cmd => cmd.Id)
            .GreaterThan(0);
    }
}