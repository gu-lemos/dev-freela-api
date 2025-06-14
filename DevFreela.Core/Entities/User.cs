namespace DevFreela.Core.Entities;

public class User(string fullName, string email, DateTime birthDate) : BaseEntity()
{
    public string FullName { get; private set; } = fullName;
    public string Email { get; private set; } = email;
    public DateTime BirthDate { get; private set; } = birthDate;
    public bool Active { get; private set; } = true;
    public List<UserSkill> Skills { get; private set; } = [];
    public List<Project> OwnedProjects { get; private set; } = [];
    public List<Project> FreelanceProjects { get; private set; } = [];
    public List<ProjectComment> Comments { get; private set; } = [];
}
