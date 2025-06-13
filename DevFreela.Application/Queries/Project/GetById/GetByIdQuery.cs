using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetById;

public class GetByIdQuery(int id) : IRequest<ResultViewModel<ProjectViewModel>>
{
    public int Id { get; set; } = id;
}
