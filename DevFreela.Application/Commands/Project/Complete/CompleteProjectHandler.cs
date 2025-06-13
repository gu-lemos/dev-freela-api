using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.Complete;

public class CompleteProjectHandler(IProjectRepository repository) : IRequestHandler<CompleteProjectCommand, ResultViewModel>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id, cancellationToken);

        if (project == null)
            return ResultViewModel.Error($"O projeto {request.Id} não existe.");

        project.Complete();

        await _repository.Update(project, cancellationToken);

        return ResultViewModel.Success();
    }
}
