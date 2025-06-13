using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetById;

public class Handler(IProjectRepository repository) : IRequestHandler<GetByIdQuery, ResultViewModel<ProjectViewModel>>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel<ProjectViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetDetailsById(request.Id, cancellationToken);

        if (project is null)
            return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");

        var model = ProjectViewModel.FromEntity(project);

        return ResultViewModel<ProjectViewModel>.Success(model);
    }
}
