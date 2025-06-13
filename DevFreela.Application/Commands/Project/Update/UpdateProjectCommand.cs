using DevFreela.Application.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace DevFreela.Application.Commands.Project.Update;

public class UpdateProjectCommand : IRequest<ResultViewModel>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int TotalCost { get; set; }
}
