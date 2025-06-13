using DevFreela.Application.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace DevFreela.Application.Commands.Project.InsertComment;

public class InsertCommentProjectCommand : IRequest<ResultViewModel>
{
    [JsonIgnore]
    public int ProjectId { get; set; }
    public string Content { get; set; } = string.Empty;
    public int IdUser { get; set; }
}
