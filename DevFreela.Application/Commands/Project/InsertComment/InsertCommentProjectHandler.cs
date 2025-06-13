using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.InsertComment;

internal class InsertCommentProjectHandler(IProjectRepository repository) : IRequestHandler<InsertCommentProjectCommand, ResultViewModel>
{
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel> Handle(InsertCommentProjectCommand request, CancellationToken cancellationToken)
    {
        var projectExists = await _repository.Exists(request.IdProject, cancellationToken);

        if (!projectExists)
            return ResultViewModel.Error($"O projeto {request.IdProject} não existe.");

        var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

        await _repository.AddComment(comment, cancellationToken);

        return ResultViewModel.Success();
    }
}
