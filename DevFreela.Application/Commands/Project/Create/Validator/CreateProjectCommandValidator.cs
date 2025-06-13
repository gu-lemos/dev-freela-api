using DevFreela.Application.Commands.Project.Create;
using FluentValidation;

namespace DevFreela.Application.Commands.Project.Create.Validator;
public class InsertProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public InsertProjectValidator()
    {
        
    }
}
