using AutoMapper;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetAll;

public class Handler(IProjectRepository repository, IMapper mapper) : IRequestHandler<GetAllQuery, ResultViewModel<List<ProjectViewModel>>>
{
    readonly private IMapper _mapper = mapper;
    readonly private IProjectRepository _repository = repository;

    public async Task<ResultViewModel<List<ProjectViewModel>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAll(cancellationToken);

        var model = _mapper.Map<List<ProjectViewModel>>(projects);

        return ResultViewModel<List<ProjectViewModel>>.Success(model);
    }
}
