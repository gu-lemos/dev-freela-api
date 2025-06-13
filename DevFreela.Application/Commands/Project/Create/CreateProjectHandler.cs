using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.Create;

public class CreateProjectHandler(IProjectRepository repository) : IRequestHandler<CreateProjectCommand, ResultViewModel<int>>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = request.ToEntity();

        var response = await _repository.Add(project, cancellationToken);

        return ResultViewModel<int>.Success(response);
    }
}
