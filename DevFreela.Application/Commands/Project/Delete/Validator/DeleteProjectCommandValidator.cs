using FluentValidation;

namespace DevFreela.Application.Commands.Project.Delete.Validator;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(cmd => cmd.Id)
            .GreaterThan(0);
    }
}