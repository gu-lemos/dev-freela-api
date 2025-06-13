using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetById;

public class GetByIdQuery : IRequest<ResultViewModel<ProjectViewModel>>
{
    public GetByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
