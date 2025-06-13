using DevFreela.Core.Entities;

namespace DevFreela.Application.Models;

public class ProjectViewModel
{
    public ProjectViewModel(int id, string title, string description, int idClient, int idFreeLancer, string clientName, string freelancerName, decimal totalCost, List<ProjectComment> comments)
    {
        Id = id;
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreeLancer = idFreeLancer;
        ClientName = clientName;
        FreelancerName = freelancerName;
        TotalCost = totalCost;
        Comments = [.. comments.Select(comment => comment.Content)];
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdClient { get; private set; }
    public int IdFreeLancer { get; private set; }
    public string ClientName { get; private set; }
    public string FreelancerName { get; private set; }
    public decimal TotalCost { get; private set; }
    public List<string> Comments { get; private set; }

    public static ProjectViewModel FromEntity(Project entity)
        => new(entity.Id, entity.Title, entity.Description, entity.IdClient,
            entity.IdFreeLancer, entity.Client.FullName, entity.FreeLancer.FullName,
            entity.TotalCost, entity.Comments);
}
