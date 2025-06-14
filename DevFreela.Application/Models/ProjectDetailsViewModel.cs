using DevFreela.Core.Enums;

namespace DevFreela.Application.Models;

public record class ProjectDetailsViewModel
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public int IdClient { get; init; }
    public int IdFreeLancer { get; init; }
    public required string ClientName { get; init; }
    public required string FreelancerName { get; init; }
    public decimal TotalCost { get; init; }
    public required string Status { get; init; }
    public List<CommentsResponse>? Comments { get; init; }

    public record CommentsResponse
    {
        public required string Content { get; init; }
        public int IdUser { get; init; }
    }
}
