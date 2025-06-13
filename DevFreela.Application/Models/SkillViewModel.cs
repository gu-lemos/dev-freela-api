using DevFreela.Core.Entities;

namespace DevFreela.Application.Models;

public class SkillViewModel
{
    public SkillViewModel(int id, string description)
    {
        Id = id;
        Description = description;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }

    public static List<SkillViewModel> FromEntity(List<Skill> skillsList)
    {
        List<SkillViewModel> listViewModel = [];

        foreach (var skill in skillsList)
            listViewModel.Add(new(skill.Id, skill.Description));

        return listViewModel;
    }
}
