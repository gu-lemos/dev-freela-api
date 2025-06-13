using FluentValidation;

namespace DevFreela.Application.Commands.Project.InsertComment.Validator;

public class InsertCommentProjectCommandValidator : AbstractValidator<InsertCommentProjectCommand>
{
    public InsertCommentProjectCommandValidator()
    {
        RuleFor(cmd => cmd.Content)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(cmd => cmd.IdProject)
            .GreaterThan(0);

        RuleFor(cmd => cmd.IdUser)
            .GreaterThan(0);
    }
}