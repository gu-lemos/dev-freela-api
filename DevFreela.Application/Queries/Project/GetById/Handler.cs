using AutoMapper;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetById;

public class Handler(IProjectRepository repository, IMapper mapper) : IRequestHandler<GetByIdQuery, ResultViewModel<ProjectDetailsViewModel>>
{
    readonly private IProjectRepository _repository = repository;
    readonly private IMapper _mapper = mapper;

    public async Task<ResultViewModel<ProjectDetailsViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetDetailsById(request.Id, cancellationToken);

        if (project is null)
            return ResultViewModel<ProjectDetailsViewModel>.Error(null, $"O projeto {request.Id} não existe.");

        var model = _mapper.Map<ProjectDetailsViewModel>(project);

        return ResultViewModel<ProjectDetailsViewModel>.Success(model);
    }
}
