using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.Delete;

public class DeleteProjectHandler(IProjectRepository repository) : IRequestHandler<DeleteProjectCommand, ResultViewModel>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id, cancellationToken);

        if (project == null)
            return ResultViewModel.Error($"O projeto {request.Id} não existe.");

        project.SetAsDeleted();

        await _repository.Update(project, cancellationToken);

        return ResultViewModel.Success();
    }
}
