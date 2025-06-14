using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project(string title, string description, int idClient, int idFreeLancer, decimal totalCost) : BaseEntity()
{
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public int IdClient { get; private set; } = idClient;
    public User Client { get; private set; } = null!;
    public int IdFreeLancer { get; private set; } = idFreeLancer;
    public User FreeLancer { get; private set; } = null!;
    public decimal TotalCost { get; private set; } = totalCost;
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; } = ProjectStatusEnum.Created;
    public List<ProjectComment> Comments { get; private set; } = [];

    public void Cancel()
    {
        if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
        {
            Status = ProjectStatusEnum.Cancelled;
        }
    }

    public void Start()
    {
        if (Status == ProjectStatusEnum.Created)
        {
            Status = ProjectStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }
    }

    public void Complete()
    {
        if (Status == ProjectStatusEnum.PaymentPending || Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Completed;
            CompletedAt = DateTime.Now;
        }
    }

    public void SetPaymentPending()
    {
        if (Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.PaymentPending;
        }
    }

    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}
