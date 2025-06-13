using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillsController : ControllerBase
{
    private readonly DevFreelaDbContext _context;

    public SkillsController(DevFreelaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var skills = _context.Skills.ToList();

        var model = SkillViewModel.FromEntity(skills);

        return Ok(model);
    }

    [HttpPost]
    public IActionResult Post(CreateSkillInputModel model)
    {
        var skill = new Skill(model.Description);

        _context.Skills.Add(skill);
        _context.SaveChanges();

        return NoContent();
    }
}
