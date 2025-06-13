using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Project.Create;

public class CreateProjectCommand : IRequest<ResultViewModel<int>>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int IdClient { get; set; }
    public int IdFreeLancer { get; set; }
    public int TotalCost { get; set; }

    public Core.Entities.Project ToEntity()
        => new(Title, Description, IdClient, IdFreeLancer, TotalCost);
}
