using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Project.Start;

public class StartProjectHandler(IProjectRepository repository) : IRequestHandler<StartProjectCommand, ResultViewModel>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id, cancellationToken);

        if (project == null)
            return ResultViewModel.Error($"O projeto {request.Id} não existe.");

        project.Start();

        await _repository.Update(project, cancellationToken);

        return ResultViewModel.Success();
    }
}
