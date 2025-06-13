using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.Update;

public class UpdateProjectHandler(IProjectRepository repository) : IRequestHandler<UpdateProjectCommand, ResultViewModel>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id, cancellationToken);

        if (project == null)
            return ResultViewModel.Error("Projeto não existe.");

        project.Update(request.Title, request.Description, request.TotalCost);

        await _repository.Update(project, cancellationToken);

        return ResultViewModel.Success();
    }
}
