namespace DevFreela.Application.Models;

public record  class ProjectViewModel
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string ClientName { get; init; }
    public required string FreelancerName { get; init; }
    public required string Status { get; init; }
    public decimal TotalCost { get; init; }
}
