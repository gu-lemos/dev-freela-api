using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetAll;

public class Handler(IProjectRepository repository) : IRequestHandler<GetAllQuery, ResultViewModel<List<ProjectItemViewModel>>>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAll(cancellationToken);

        var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
    }
}
